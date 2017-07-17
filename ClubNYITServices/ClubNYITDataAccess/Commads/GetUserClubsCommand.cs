using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetUserClubsCommand : DbCommand
    {
        public static IList<ClubDetail> Execute(long UserID)
        {

            IList<ClubDetail> clubAdvisorList = null;
            clubAdvisorList = (from ucr in db.UserClubRoleDetails
                               join c in db.ClubDetails on ucr.UserID equals UserID
                               where ucr.ClubID == c.ClubID 
                               select c).ToList<ClubDetail>();
           
            return clubAdvisorList;
        }
    }
}
