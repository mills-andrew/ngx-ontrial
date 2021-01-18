using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InvalidElementStateException : Exception
    {
        public InvalidElementStateException(string pMessage) : base(pMessage)
        {

        }

        public InvalidElementStateException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
