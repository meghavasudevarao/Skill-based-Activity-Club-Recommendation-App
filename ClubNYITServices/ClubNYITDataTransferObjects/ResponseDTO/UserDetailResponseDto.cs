using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.ResponseDTO
{
    public class UserDetailResponseDto
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public bool isAdmin { get; set; }

    }
}
