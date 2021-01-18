using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InvalidCookieDomainException : Exception
    {
        public InvalidCookieDomainException(string pMessage) : base(pMessage)
        {

        }

        public InvalidCookieDomainException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
