using System;

namespace OnTrial.Web
{
    [Serializable]
    public class NoSuchWindowException : Exception
    {
        public NoSuchWindowException(string pMessage) : base(pMessage)
        {
            
        }

        public NoSuchWindowException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}