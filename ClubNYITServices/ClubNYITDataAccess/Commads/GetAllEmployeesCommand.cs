using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    class GetAllEmployeesCommand : DbCommand
    {
        public static IList<UserDetail> Execute()
        {
            IList<UserDetail> userList = db.UserDetails.ToList<UserDetail>();

            return userList.Where(u => u.StudentID.Equals(null)).ToList<UserDetail>();
            
        }
    }
}
