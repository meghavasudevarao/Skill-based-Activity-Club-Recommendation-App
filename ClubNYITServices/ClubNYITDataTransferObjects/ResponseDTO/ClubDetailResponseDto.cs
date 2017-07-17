using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.ResponseDTO
{
    public class ClubDetailResponseDto
    {
        public long ClubID { get; set; }
        public string ClubName { get; set; }
        public string ClubLogo { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Advisor { get; set; }
        public string MeetingDates { get; set; }
        public bool isInternatinalClub { get; set; }
        public bool isTechnologyClub { get; set; }
        public bool isActive { get; set; }
        public int MemberCount { get; set; }
    }
}
