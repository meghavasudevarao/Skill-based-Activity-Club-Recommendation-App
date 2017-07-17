using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.ResponseDTO
{
    public class EventDetailResponseDto
    {
        public long EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string Cordinator { get; set; }
        public string Location { get; set; }
        public bool isHidden { get; set; }
    }
}
