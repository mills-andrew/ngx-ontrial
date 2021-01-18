using System;

namespace OnTrial.Web
{
    [Serializable]
    public class InvalidSessionIdException : Exception
    {
        public InvalidSessionIdException(string pMessage) : base(pMessage)
        {
            
        }

        public InvalidSessionIdException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}