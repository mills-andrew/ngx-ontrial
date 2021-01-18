using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class NoSuchWindowException : Exception
    {
        public NoSuchWindowException(string pMessage) : base(pMessage)
        {

        }

        public NoSuchWindowException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
