using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetClubDetailCommand : DbCommand
    {
        public static ClubDetail Execute(long ClubID)
        {
            var clubList = db.ClubDetails.ToList<ClubDetail>();
            ClubDetail clubDetail = null;
            clubDetail = clubList.Where(c => c.ClubID == ClubID).FirstOrDefault< ClubDetail>();
            return clubDetail;

        }
    }
}
