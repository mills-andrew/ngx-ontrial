using System;

namespace OnTrial.Web
{
    [Serializable]
    public class InvalidPageException : Exception
    {
        public InvalidPageException(string pMessage) : base(pMessage)
        {
            
        }

        public InvalidPageException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}