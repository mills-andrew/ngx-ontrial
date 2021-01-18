using System;

namespace OnTrial.Web
{
    [Serializable]
    public class UnableToCaptureScreenException : Exception
    {
        public UnableToCaptureScreenException(string pMessage) : base(pMessage)
        {
            
        }

        public UnableToCaptureScreenException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}