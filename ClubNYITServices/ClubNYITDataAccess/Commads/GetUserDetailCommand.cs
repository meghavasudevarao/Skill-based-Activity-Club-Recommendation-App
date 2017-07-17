using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetUserDetailCommand : DbCommand
    {
        public static UserDetail Execute(string LinkedInUserID)
        {
            var userList = db.UserDetails.ToList<UserDetail>();
            UserDetail userDetail = null;
            userDetail = userList.Where(u => u.LinkedInUserID == LinkedInUserID).FirstOrDefault<UserDetail>();
            return userDetail;

        }
    }
}
