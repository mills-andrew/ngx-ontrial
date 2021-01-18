using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string pMessage) : base(pMessage)
        {

        }

        public InvalidArgumentException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
