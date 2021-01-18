using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnknownMethodException : Exception
    {
        public UnknownMethodException(string pMessage) : base(pMessage)
        {
            
        }

        public UnknownMethodException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}