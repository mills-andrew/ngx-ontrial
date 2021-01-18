using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException(string pMessage) : base(pMessage)
        {
            
        }

        public UnknownCommandException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}