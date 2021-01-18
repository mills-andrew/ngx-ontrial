using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnableToSetCookieException : Exception
    {
        public UnableToSetCookieException(string pMessage) : base(pMessage)
        {

        }

        public UnableToSetCookieException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
