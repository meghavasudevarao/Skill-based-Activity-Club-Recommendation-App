using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.RequestDTO
{
    public class GetRecomendedClubsRequestDto
    {
        public long UserID { get; set; }
        public IList<string> Skill { get; set; }
        public IList<string> Interest { get; set; }
    }
}
