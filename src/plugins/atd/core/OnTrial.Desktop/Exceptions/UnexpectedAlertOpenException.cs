using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnexpectedAlertOpenException : Exception
    {
        public UnexpectedAlertOpenException(string pMessage) : base(pMessage)
        {

        }

        public UnexpectedAlertOpenException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
