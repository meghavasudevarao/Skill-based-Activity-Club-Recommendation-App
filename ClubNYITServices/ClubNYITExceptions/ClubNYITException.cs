using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubNYITExceptions
{
    public class ClubNYITException : Exception
    {
        public int ExceptionCode { get; set; }
        public string ExceptionMessage { get; set; }
        public Exception InnerException { get; set; }

        public ClubNYITException(int ExceptionCode, string ExceptionMessage)
        {
            this.ExceptionCode = ExceptionCode;
            this.ExceptionMessage = ExceptionMessage;
        }
        public ClubNYITException(int ExceptionCode, string ExceptionMessage, Exception InnerException)
        {
            this.ExceptionCode = ExceptionCode;
            this.ExceptionMessage = ExceptionMessage;
            this.InnerException = InnerException;
        }

        public int GetExceptionCode(ClubNYITException ClubNYITException)
        {
            return ClubNYITException.ExceptionCode;
        }

    }
}
