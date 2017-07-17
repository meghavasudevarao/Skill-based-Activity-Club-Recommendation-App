using ClubNYITExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class AddClubCommand : DbCommand
    {
        public static ClubDetail Execute(ClubDetail clubDetail, UserClubRoleDetail userClubRoleDetail)
        {
            ClubDetail club = null;
            UserClubRoleDetail userClubRole = null;
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                     club = db.ClubDetails.Add(clubDetail);
                    db.SaveChanges();
                    userClubRoleDetail.ClubID = club.ClubID;
                    userClubRole= db.UserClubRoleDetails.Add(userClubRoleDetail);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return club;
                    
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
