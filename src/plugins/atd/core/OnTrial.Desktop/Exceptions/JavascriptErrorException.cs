using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class JavascriptErrorException : Exception
    {
        public JavascriptErrorException(string pMessage) : base(pMessage)
        {

        }

        public JavascriptErrorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
