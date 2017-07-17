using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    
    public class UserRepository
    {
        public UserDetail GetUserDetails(string LinkedInUserID)
        {
            return GetUserDetailCommand.Execute(LinkedInUserID);
        }
        public ClubDetail GetClubDetails(long ClubID)
        {
            return GetClubDetailCommand.Execute(ClubID);
        }
         public IList<EventDetail> GetEvents(long ClubID)
        {
            return GetEventsCommand.Execute(ClubID);
        }
        public EventDetail GetEventDetails(long EventID)
        {
            return GetEventDetailCommand.Execute(EventID);
        }
        public ClubDetail GetClubDetailsByClubID(long ClubID)
        {
            return GetClubDetailByClubIDCommand.Execute(ClubID);
        }
        public UserDetail GetUserDetailsByUseID(long UserID)
        {
            return GetUserDetailByUserIDCommand.Execute(UserID);
        }
        public UserClubRoleDetail AddClubUser(UserClubRoleDetail userClubRoleDetail)
        {
            return AddClubUserCommand.Execute(userClubRoleDetail);
        }
   
        public IList<ClubDetail> GetAllClubs()
        {
            return GetAllClubsCommand.Execute();
        }
    }
}
