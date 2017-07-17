using ClubNYITExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class AddUserCommand : DbCommand
    {
        public static UserDetail Execute(UserDetail userDetail)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    UserDetail user = db.UserDetails.Add(userDetail);
                    db.SaveChanges();
                    db.Database.CurrentTransaction.Commit();
                    return user;
                    
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    throw new ClubNYITException(ExceptionCodes.DataExists, ExceptionMessages.DataExists, e);
                }
            }
        }

    }
}
