using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class RegisterationRepository
    {
        public UserDetail AddUser(UserDetail userDetail)
        {
            return AddUserCommand.Execute(userDetail);
        }
    }
}
