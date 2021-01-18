using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class NoSuchAlertException : Exception
    {
        public NoSuchAlertException(string pMessage) : base(pMessage)
        {

        }

        public NoSuchAlertException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
