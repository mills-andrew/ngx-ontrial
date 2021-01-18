using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnexpectedAlertOpenException : Exception
    {
        public UnexpectedAlertOpenException(string pMessage) : base(pMessage)
        {
            
        }

        public UnexpectedAlertOpenException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}