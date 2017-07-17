using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.RequestDTO
{
    public class RegisterUserRequestDto
    {
        public string UserName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public long? StudentID { get; set; }
        public long? EmployeeID { get; set; }
        public string NYITEmailID { get; set; }
        public string LinkedInUserID { get; set; }
        public string Gender { get; set; }
        public bool Aluminus { get; set; }
        public string Major { get; set; }
        public int Natinality { get; set; }
        public string PhoneNumber { get; set; }
    }
}
