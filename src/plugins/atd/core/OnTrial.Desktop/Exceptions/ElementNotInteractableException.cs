using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
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
