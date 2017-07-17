using ClubNYITDataAccess;
using ClubNYITDataTransferObjects.RequestDTO;
using ClubNYITDataTransferObjects.ResponseDTO;
using ClubNYITExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNyitBusiness
{
    public class AdminDashboard
    {
        AdminRepository adminRepository = null;
   
        public AdminDashboard()
        {
            adminRepository = new AdminRepository();
        }
        
        #region Public Methods
        public CreateClubResponseDto CreateClub(CreateClubRequestDto createClubRequestDto)
        {
            ValidateCreateClubRequestDto(createClubRequestDto);
                if (adminRepository.GetUserDetailsByUseID(createClubRequestDto.Advisor) != null)
            {
                var clubDetail = EntityMapper.MapCreateClubRequesttoClubDetail(createClubRequestDto);
                clubDetail.ClubGUID = Guid.NewGuid();
                var userClubRoleDetail = new UserClubRoleDetail();
                userClubRoleDetail.RoleID = (int)BusinessEnumerations.Role.Admin;
                userClubRoleDetail.UserID = createClubRequestDto.Advisor;
                var club = adminRepository.AddClub(clubDetail, userClubRoleDetail);
                return new CreateClubResponseDto { ClubID = club.ClubID };
            }
                throw new ClubNYITException(ExceptionCodes.InvalidAuthorization, ExceptionMessages.InvalidAuthorization);

        }

        public CreateEventResponseDto CreateEvent(CreateEventRequestDto createEventRequestDto)
        {
            ValidateCreateEventRequestDto(createEventRequestDto);
            if (adminRepository.GetClubDetailsByClubID(createEventRequestDto.ClubID)== null || adminRepository.GetUserDetailsByUseID(createEventRequestDto.Cordinator) == null)
                throw new ClubNYITException(ExceptionCodes.InvalidOperation, ExceptionMessages.InvalidOperation);

                var eventDetail = EntityMapper.MapCreateEventRequesttoEventDetail(createEventRequestDto);
                eventDetail.EventGUID = new Guid();
                var eventadded = adminRepository.AddEvent(eventDetail);
                return new CreateEventResponseDto { EventID = eventadded.EventID }; 

        }

        public GetAllEmployeesResponseDto GetAllEmployees()
        {
            var eUser = adminRepository.GetAllEmployees();

            return EntityMapper.MapUserDetailtoGetAllEmployeesResponse(eUser);
        }

        public GetAllStudentsResponseDto GetAllStudents()
        {
            var sUser = adminRepository.GetAllStudents();

            return EntityMapper.MapUserDetailtoGetAllStudentsResponse(sUser);
        }

        #endregion

        #region Private Methods
        private void ValidateCreateClubRequestDto(CreateClubRequestDto createClubRequestDto)
        {
            if (createClubRequestDto.Advisor < 1 ||
                string.IsNullOrWhiteSpace(createClubRequestDto.ClubDescription) ||
                string.IsNullOrWhiteSpace(createClubRequestDto.ClubLocation) ||
                string.IsNullOrWhiteSpace(createClubRequestDto.ClubLogo) ||
                string.IsNullOrWhiteSpace(createClubRequestDto.ClubName) ||
                string.IsNullOrWhiteSpace(createClubRequestDto.MeetingDates))
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }
        private void ValidateCreateEventRequestDto(CreateEventRequestDto createEventRequestDto)
        {
            if(createEventRequestDto.ClubID < 1 ||
                createEventRequestDto.Cordinator < 1 ||
                createEventRequestDto.Date == null ||
                string.IsNullOrWhiteSpace(createEventRequestDto.Description) ||
                string.IsNullOrWhiteSpace(createEventRequestDto.EventName) ||
                string.IsNullOrWhiteSpace(createEventRequestDto.Location))
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);

        }

        private IList<ClubResponseDto> GetAllClubs()
        {
            IList<ClubDetail> club = adminRepository.GetAllClubs();
            var clubResponseDto = EntityMapper.MapClubDetailtoClubResponse(club);
            return clubResponseDto;
        }
        #endregion
    }
}
