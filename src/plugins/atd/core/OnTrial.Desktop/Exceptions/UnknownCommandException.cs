using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException(string pMessage) : base(pMessage)
        {

        }

        public UnknownCommandException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
