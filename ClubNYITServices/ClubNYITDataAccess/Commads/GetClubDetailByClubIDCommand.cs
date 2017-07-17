using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetClubDetailByClubIDCommand : DbCommand
    {
        public static ClubDetail Execute(long ClubID)
        {
            var club = db.ClubDetails.Find(ClubID);
            return club;
        }
    }
}
