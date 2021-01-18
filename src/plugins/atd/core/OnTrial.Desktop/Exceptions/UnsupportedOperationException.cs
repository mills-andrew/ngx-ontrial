using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string pMessage) : base(pMessage)
        {

        }

        public UnsupportedOperationException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
