using System;

namespace OnTrial.Web
{
    [Serializable]
    public class ElementNotInteractableException : Exception
    {
        public ElementNotInteractableException(string pMessage) : base(pMessage)
        {
            
        }

        public ElementNotInteractableException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}