using System;

namespace OnTrial.Web
{
    [Serializable]
    public class NoSuchAlertException : Exception
    {
        public NoSuchAlertException(string pMessage) : base(pMessage)
        {
            
        }

        public NoSuchAlertException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}