using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnknownErrorException : Exception
    {
        public UnknownErrorException(string pMessage) : base(pMessage)
        {

        }

        public UnknownErrorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
