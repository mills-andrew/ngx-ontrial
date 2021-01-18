using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class NoSuchElementException : Exception
    {
        public NoSuchElementException(string pMessage) : base(pMessage)
        {

        }

        public NoSuchElementException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
