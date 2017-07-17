using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetUserDetailByUserIDCommand : DbCommand
    {
        public static UserDetail Execute(long UserID)
        {
            var userList = db.UserDetails.ToList<UserDetail>();
            UserDetail userDetail = null;
            userDetail = userList.Where(u => u.UserID == UserID).FirstOrDefault<UserDetail>();
            return userDetail;

        }
    }
}
