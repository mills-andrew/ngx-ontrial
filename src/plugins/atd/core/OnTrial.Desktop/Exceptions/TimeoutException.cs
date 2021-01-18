using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class TimeoutException : Exception
    {
        public TimeoutException(string pMessage) : base(pMessage)
        {

        }

        public TimeoutException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
