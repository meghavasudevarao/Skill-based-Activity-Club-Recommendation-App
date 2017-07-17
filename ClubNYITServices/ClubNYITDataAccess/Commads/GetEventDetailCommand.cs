using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetEventDetailCommand : DbCommand
    {
        public static EventDetail Execute(long EventID)
        {
            var eventList = db.EventDetails.ToList<EventDetail>();
            EventDetail eventDetail = null;
            eventDetail = eventList.Where(e => e.EventID == EventID).FirstOrDefault<EventDetail>();
            return eventDetail;

        }
    }
}
