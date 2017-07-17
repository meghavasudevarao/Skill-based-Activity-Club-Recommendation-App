using ClubNYITExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class AddEventCommand : DbCommand
    {
        public static EventDetail Execute(EventDetail eventDetail)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                var clubList = db.ClubDetails.ToList<ClubDetail>();

                var clubDetail = clubList.Where(c => c.ClubID == eventDetail.ClubID).FirstOrDefault<ClubDetail>();
                if(clubDetail==null)
                    throw new ClubNYITException(ExceptionCodes.InvalidOperation, ExceptionMessages.InvalidOperation);
                try
                {
                    var eventadded = db.EventDetails.Add(eventDetail);
                    db.SaveChanges();
                    db.Database.CurrentTransaction.Commit();
                    return eventadded;
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
