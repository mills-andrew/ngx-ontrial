using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class NoSuchCookieException : Exception
    {
        public NoSuchCookieException(string pMessage) : base(pMessage)
        {

        }

        public NoSuchCookieException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
