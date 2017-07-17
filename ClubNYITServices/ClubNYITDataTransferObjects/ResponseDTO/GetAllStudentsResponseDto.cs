using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITDataTransferObjects.ResponseDTO
{
    public class GetAllStudentsResponseDto
    {
        public IList<UserDetailResponseDto> UserDetailResponseDto { get; set; }
    }
}
