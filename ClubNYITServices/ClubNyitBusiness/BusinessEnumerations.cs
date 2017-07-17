using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNyitBusiness
{
    public class BusinessEnumerations
    {
        public enum Role
        {
            Admin = 0,
            User = 1
        };

        public enum Gender
        {
            Female = 1,
            Male = 2,
            DontWiashToSpecify=3
        };

        public static int GetValue(string enumstring)
        {
            if (enumstring=="Admin")
                return 2001;
            if (enumstring == "User")
                return 1;
            if (enumstring == "Female")
                return 1;
            if (enumstring == "Male")
                return 2;
            if (enumstring == "DontWiashToSpecify")
                return 3;
            else
                return 0;

        }

    }
}
