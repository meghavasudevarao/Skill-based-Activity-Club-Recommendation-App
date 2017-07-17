using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.RequestDTO
{
    public class CreateEventRequestDto
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public long ClubID { get; set; }
        public System.DateTime Date { get; set; }
        public long Cordinator { get; set; }
        public string Location { get; set; }
        public bool Hidden { get; set; }
    }
}
