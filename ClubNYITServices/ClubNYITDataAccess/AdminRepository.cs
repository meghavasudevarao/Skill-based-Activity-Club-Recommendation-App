using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class AdminRepository
    {
        public IList<UserDetail> GetAllEmployees()
        {
            return GetAllEmployeesCommand.Execute();
        }
        public UserDetail GetUserDetailsByUseID(long UserID)
        {
            return GetUserDetailByUserIDCommand.Execute(UserID);
        }
        public IList<UserDetail> GetAllStudents()
        {
            return GetAllStudentsCommand.Execute();
        }
        public ClubDetail GetClubDetailsByClubID(long ClubID)
        {
            return GetClubDetailByClubIDCommand.Execute(ClubID);
        }
        public ClubDetail AddClub(ClubDetail clubDetail, UserClubRoleDetail userClubRoleDetail)
        {
            return AddClubCommand.Execute(clubDetail, userClubRoleDetail);
        }
        public EventDetail AddEvent(EventDetail eventDetail)
        {
            return AddEventCommand.Execute(eventDetail);
        }
        public IList<ClubDetail> GetAdvisorClubs(long AdvisorUserID)
        {
            return GetAdvisorClubsCommand.Execute(AdvisorUserID);
        }
        public IList<ClubDetail> GetAllClubs()
        {
            return GetAllClubsCommand.Execute();
        }

    }
}
