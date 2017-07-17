using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetAllStudentsCommand:DbCommand
    {
        public static IList<UserDetail> Execute()
        {
            IList<UserDetail> userList = db.UserDetails.ToList<UserDetail>();

            return userList.Where(u => u.EmployeeID.Equals(null)).ToList<UserDetail>();
            //return userList.Where(u=> u.StudentID!= null).ToList< UserDetail>();

        }
    }
}
