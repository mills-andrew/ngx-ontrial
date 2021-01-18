using System;

namespace OnTrial.Web
{
    [Serializable]
    public class NoSuchCookieException : Exception
    {
        public NoSuchCookieException(string pMessage) : base(pMessage)
        {
            
        }

        public NoSuchCookieException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}