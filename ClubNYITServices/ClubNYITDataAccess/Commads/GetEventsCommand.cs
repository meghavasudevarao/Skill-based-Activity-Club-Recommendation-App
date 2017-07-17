using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetEventsCommand : DbCommand
    {
        public static IList<EventDetail> Execute(long ClubID)
        {
            var eventList = db.EventDetails.ToList<EventDetail>();
            IList<EventDetail> eventDetail = null;
            eventDetail = eventList.Where(e => e.ClubID == ClubID).ToList<EventDetail>();
            return eventDetail;

        }
        
    }
}
