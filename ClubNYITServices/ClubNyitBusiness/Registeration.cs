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
    public class Registeration
    {
        RegisterationRepository registerationRepository = null;
        

        public Registeration()
        {
            registerationRepository = new RegisterationRepository();

        }

        #region Public Methods

        public RegisterUserResponseDto RegisterUser(RegisterUserRequestDto registerUserRequestDto)
        {
            ValidateRegisterUserRequestDto(registerUserRequestDto);
            ///TO DO chech if an account exists with provided linkedin userID  
            UserDetail userDetail = EntityMapper.MapRegisterUserRequesttoUserDetai(registerUserRequestDto);
            userDetail.UserGUID = Guid.NewGuid();
            userDetail.Gender = BusinessEnumerations.GetValue(registerUserRequestDto.Gender);
            var user = registerationRepository.AddUser(userDetail);
            return new RegisterUserResponseDto {  UserID= user.UserID};
        }

        #endregion

        #region Private Methods

        private void ValidateRegisterUserRequestDto(RegisterUserRequestDto registerUserRequestDto)
        {
            if(registerUserRequestDto.DateOfBirth == null ||
               ( registerUserRequestDto.EmployeeID == null && registerUserRequestDto.StudentID == null ) ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.Gender) ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.LinkedInUserID) ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.Major) ||
                registerUserRequestDto.Natinality < 0 ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.NYITEmailID) ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.PhoneNumber) ||
                string.IsNullOrWhiteSpace(registerUserRequestDto.UserName))
                throw new ClubNYITException(ExceptionCodes.InvalidInput, ExceptionMessages.InvalidInput);

        }
        #endregion

    }
}
