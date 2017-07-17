using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.ResponseDTO
{
   public  class EventResponseDto
    {
        public long EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
