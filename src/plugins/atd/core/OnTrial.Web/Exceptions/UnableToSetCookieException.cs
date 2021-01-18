using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnableToSetCookieException : Exception
    {
        public UnableToSetCookieException(string pMessage) : base(pMessage)
        {
            
        }

        public UnableToSetCookieException(string pMessage, Exception innerException) : base(pMessage, innerException)
        {
            
        }
    }
}