using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
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
