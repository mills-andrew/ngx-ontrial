using System;

namespace OnTrial.Web
{
    [Serializable]
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string pMessage) : base(pMessage)
        {
            
        }

        public InvalidArgumentException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}