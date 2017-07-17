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
    public class UserDashboard
    {
        UserRepository userRepository = null;

        public UserDashboard()
        {
            userRepository = new UserRepository();
        }

        #region Public Methods
        public UserDetailResponseDto GetUserDetails(UserDetailRequestDto userDetailRequestDto)
        {
            ValidateUserDetailRequestDto(userDetailRequestDto);
            var userDetail = userRepository.GetUserDetails(userDetailRequestDto.LinlkedInUserID);
            var userDetailResponseDto = EntityMapper.MapUserDetailtoUserDetailResponse(userDetail);
            if (userDetail.EmployeeID != null)
                userDetailResponseDto.isAdmin = true;
            return userDetailResponseDto;
        }

        public ClubDetailResponseDto GetClubDetails(ClubDetailRequestDto clubDetailRequestDto)
        {
            ValidateClubDetailRequestDto(clubDetailRequestDto);
            var clubDetail = userRepository.GetClubDetails(clubDetailRequestDto.ClubID);
            var clubDetailResponseDto = EntityMapper.MapClubDetailtoClubDetailResponse(clubDetail);
            var userDetail = userRepository.GetUserDetailsByUseID(clubDetail.Advisor);
            clubDetailResponseDto.Advisor = userDetail.UserName;
            return clubDetailResponseDto;
        }

        public IList<EventResponseDto> GetEvents(EventRequestDto eventRequestDto)
        {
            ValidateEventRequestDto(eventRequestDto);
            var eventsDetail = userRepository.GetEvents(eventRequestDto.ClubID);
            var eventResponseDto = EntityMapper.MapEventDetailtoEventResponse(eventsDetail);
            return eventResponseDto;
        }

        public EventDetailResponseDto GetEventDetails(EventDetailRequestDto eventDetailRequestDto)
        {
            ValidateEventDetailRequestDto(eventDetailRequestDto);
            var eventDetail = userRepository.GetEventDetails(eventDetailRequestDto.EventID);
            var eventResponseDto = EntityMapper.MapEventDetailtoEventDetailResponse(eventDetail);
            return eventResponseDto;
        }

        public JoinClubResponseDto JoinClub(JoinClubRequestDto joinClubRequestDto)
        {
            ValidateJoinClubRequestDto(joinClubRequestDto);

            var userClubRoleDetail = new UserClubRoleDetail
            {
                ClubID = joinClubRequestDto.ClubID,
                RoleID = (int)BusinessEnumerations.Role.User,
                UserID = joinClubRequestDto.UserID,
                Status = true
            };
            var userClubRole = userRepository.AddClubUser(userClubRoleDetail);
            return new JoinClubResponseDto { UserClubRoleID = userClubRole.UserClubRoleID };

        }

        public IList<ClubResponseDto>GetRecomendedClubs(GetRecomendedClubsRequestDto getRecomendedClubsRequestDto)
        {
           // ValidateGetRecomendedClubsRequestDto(getRecomendedClubsRequestDto);
            IList<ClubDetail> club = userRepository.GetAllClubs();
            var clubResponseDto = EntityMapper.MapClubDetailtoClubResponse(club);
            return clubResponseDto;
        }

        #endregion

        #region Private Methods

        private void ValidateUserDetailRequestDto(UserDetailRequestDto userDetailRequestDto)
        {
            if (string.IsNullOrWhiteSpace(userDetailRequestDto.LinlkedInUserID))
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }

        private void ValidateClubDetailRequestDto(ClubDetailRequestDto clubDetailRequestDto)
        {
            if(clubDetailRequestDto.ClubID < 1)
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }

        private void ValidateEventRequestDto(EventRequestDto eventRequestDto)
        {
            if(eventRequestDto.ClubID < 1)
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }

        private void ValidateEventDetailRequestDto(EventDetailRequestDto eventDetailRequestDto)
        {
            if(eventDetailRequestDto.EventID < 1)
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }

        private void ValidateJoinClubRequestDto(JoinClubRequestDto joinClubRequestDto)
        {
            if (joinClubRequestDto.ClubID < 1 || joinClubRequestDto.UserID < 1 )
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);

        }

        private void ValidateGetRecomendedClubsRequestDto(GetRecomendedClubsRequestDto getRecomendedClubsRequestDto)
        {
            if(getRecomendedClubsRequestDto.UserID < 1)
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);
        }

        #endregion

    }
}
