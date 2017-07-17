using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public class GetAllClubsCommand: DbCommand
    {
        public static IList<ClubDetail> Execute()
        {
            IList<ClubDetail> clubList = db.ClubDetails.ToList<ClubDetail>();
            return clubList;

        }
    }
}
