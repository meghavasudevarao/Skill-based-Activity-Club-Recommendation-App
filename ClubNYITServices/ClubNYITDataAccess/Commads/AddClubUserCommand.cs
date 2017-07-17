using ClubNYITExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class AddClubUserCommand : DbCommand
    {
        public static UserClubRoleDetail Execute(UserClubRoleDetail userClubRoleDetail)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var userClubRole = db.UserClubRoleDetails.Add(userClubRoleDetail);
                    db.SaveChanges();
                    db.Database.CurrentTransaction.Commit();
                    return userClubRole;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    throw new ClubNYITException(ExceptionCodes.DataExists, ExceptionMessages.DataExists,e);
                }
            }
        }
    }
}
