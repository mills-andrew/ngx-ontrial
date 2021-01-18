using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnknownMethodException : Exception
    {
        public UnknownMethodException(string pMessage) : base(pMessage)
        {

        }

        public UnknownMethodException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
