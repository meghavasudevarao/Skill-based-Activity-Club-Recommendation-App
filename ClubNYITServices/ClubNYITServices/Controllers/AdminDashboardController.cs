using ClubNyitBusiness;
using ClubNYITDataTransferObjects.RequestDTO;
using ClubNYITDataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ClubNYITServices.Controllers
{
    public class AdminDashboardController : ApiController
    {
        AdminDashboard adminDashboard = null;
        public AdminDashboardController()
        {
            adminDashboard = new AdminDashboard();
        }

        [HttpPost]
        public CreateClubResponseDto CreateClub(CreateClubRequestDto createClubRequestDto)
        {
            return adminDashboard.CreateClub(createClubRequestDto);
        }

        [HttpPost]
        public CreateEventResponseDto CreateEvent(CreateEventRequestDto createEventRequestDto)
        {
            return adminDashboard.CreateEvent(createEventRequestDto);
        }

        [HttpPost]
        public IList<GetAllEmployeesResponseDto> GetAllEmployees()
        {
            return adminDashboard.GetAllEmployees();
        }

        [HttpPost]
        public IList<GetAllStudentsResponseDto> GetAllStudents()
        {
            return adminDashboard.GetAllStudents();
        }
    }
}
