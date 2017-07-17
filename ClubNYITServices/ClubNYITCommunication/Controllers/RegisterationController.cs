using ClubNyitBusiness;
using ClubNYITDataTransferObjects.RequestDTO;
using ClubNYITDataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ClubNYITServices.Controllers
{
    public class RegisterationController : ApiController
    {
        Registeration registeration = null;

        public RegisterationController()
        {
            registeration = new Registeration();
        }

        [HttpPost]
        public RegisterUserResponseDto RegisterUser(RegisterUserRequestDto registerUserRequestDto)
        {
            return registeration.RegisterUser(registerUserRequestDto);
        }
    }
}
