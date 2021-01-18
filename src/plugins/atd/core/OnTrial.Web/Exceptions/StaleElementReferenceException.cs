using System;

namespace OnTrial.Web
{
    [Serializable]
    public class StaleElementReferenceException : Exception
    {
        public StaleElementReferenceException(string pMessage) : base(pMessage)
        {
            
        }

        public StaleElementReferenceException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}