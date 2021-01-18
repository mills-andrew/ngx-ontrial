using System;

namespace OnTrial.Web
{
    [Serializable]
    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string pMessage) : base(pMessage)
        {
            
        }

        public InvalidSelectorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}