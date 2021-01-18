using System;

namespace OnTrial.Web
{
    [Serializable]
    public class NoSuchFrameException : Exception
    {
        public NoSuchFrameException(string pMessage) : base(pMessage)
        {
            
        }

        public NoSuchFrameException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}