using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string pMessage) : base(pMessage)
        {
            
        }

        public UnsupportedOperationException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}