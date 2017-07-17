using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataAccess
{
    public abstract class DbCommand
    {
        protected static CNyitEntities1 db = new CNyitEntities1();
    }
}
