using System;

namespace OnTrial.Web
{
    [Serializable]
    public class InvalidElementStateException : Exception
    {
        public InvalidElementStateException(string pMessage) : base(pMessage)
        {
            
        }

        public InvalidElementStateException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}