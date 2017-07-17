using System.Collections.Generic;
using System.Linq;

namespace ClubNYITDataAccess
{
    public class GetAdvisorClubsCommand : DbCommand
    {
        public static IList<ClubDetail> Execute(long AdvisorUserID)
        {
            //var clubList = db.ClubDetails.ToList<ClubDetail>();
            IList<ClubDetail> clubAdvisorList = null;
            clubAdvisorList = (from c in db.ClubDetails
                               join u in db.UserDetails on c.Advisor equals AdvisorUserID
                               where u.EmployeeID != null
                               select c).ToList<ClubDetail>();
            //clubList.Where(c => c.Advisor == AdvisorUserId ).ToList<ClubDetail>();
            return clubAdvisorList;
        }
    }
}
