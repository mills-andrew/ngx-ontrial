using System;

namespace OnTrial.Web
{
    [Serializable]
    public class ElementClickInterceptedException : Exception
    {
        public ElementClickInterceptedException(string pMessage) : base(pMessage)
        {
            
        }

        public ElementClickInterceptedException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}