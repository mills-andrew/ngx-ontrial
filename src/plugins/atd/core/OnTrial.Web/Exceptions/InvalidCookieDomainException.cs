using System;

namespace OnTrial.Web
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