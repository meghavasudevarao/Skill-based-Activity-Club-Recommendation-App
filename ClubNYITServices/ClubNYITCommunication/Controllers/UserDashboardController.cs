using ClubNyitBusiness;
using ClubNYITDataTransferObjects.RequestDTO;
using ClubNYITDataTransferObjects.ResponseDTO;
using System.Collections.Generic;
using System.Web.Http;

namespace ClubNYITServices.Controllers
{
    public class UserDashboardController : ApiController
    {
        UserDashboard userDashboard = null;

        public UserDashboardController()
        {
            userDashboard = new UserDashboard();
        }

        [HttpPost]
        public UserDetailResponseDto GetUserDetails(UserDetailRequestDto userDetailRequestDto)
        {
            return userDashboard.GetUserDetails(userDetailRequestDto);
        }

        [HttpPost]
        public ClubDetailResponseDto GetClubDetails(ClubDetailRequestDto clubDetailRequestDto)
        {
            return userDashboard.GetClubDetails(clubDetailRequestDto);
        }

        [HttpPost]
        public IList<EventResponseDto> GetEvents(EventRequestDto eventRequestDto)
        {
            return userDashboard.GetEvents(eventRequestDto);
        }

        [HttpPost]
        public EventDetailResponseDto GetEventDetails(EventDetailRequestDto eventDetailRequestDto)
        {
            return userDashboard.GetEventDetails(eventDetailRequestDto);
        }

        [HttpPost]
        public JoinClubResponseDto JoinClub(JoinClubRequestDto joinClubRequestDto)
        {
            return userDashboard.JoinClub(joinClubRequestDto);
        }

        [HttpPost]
        public IList<ClubResponseDto> GetRecomendedClubs(GetRecomendedClubsRequestDto getRecomendedClubsRequestDto)
        {
            return userDashboard.GetRecomendedClubs(getRecomendedClubsRequestDto);
        }
    }
}
