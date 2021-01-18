using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
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
