using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnknownErrorException : Exception
    {
        public UnknownErrorException(string pMessage) : base(pMessage)
        {
            
        }

        public UnknownErrorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}