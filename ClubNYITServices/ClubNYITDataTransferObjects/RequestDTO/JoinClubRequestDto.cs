using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.RequestDTO
{
    public class JoinClubRequestDto
    {
        public long UserID { get; set; }
        public long ClubID { get; set; }
    }
}
