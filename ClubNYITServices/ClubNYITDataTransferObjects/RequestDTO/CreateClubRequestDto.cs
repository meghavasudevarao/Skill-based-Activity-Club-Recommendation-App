using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.RequestDTO
{
    public class CreateClubRequestDto
    {
        public string ClubName { get; set; }
        public string ClubLogo { get; set; }
        public string ClubDescription { get; set; }
        public string ClubLocation { get; set; }
        public long Advisor { get; set; }
        public string MeetingDates { get; set; }
        public bool Internatinal { get; set; }
        public bool Technology { get; set; }
        public bool Active { get; set; }
    }
}
