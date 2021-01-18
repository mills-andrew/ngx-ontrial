using System;

namespace OnTrial.Web
{
    [Serializable]
    public class NoSuchElementException : Exception
    {
        public NoSuchElementException(string pMessage) : base(pMessage)
        {
            
        }

        public NoSuchElementException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}
