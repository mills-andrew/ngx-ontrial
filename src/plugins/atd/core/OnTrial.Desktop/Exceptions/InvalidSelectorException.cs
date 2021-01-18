using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string pMessage) : base(pMessage)
        {

        }

        public InvalidSelectorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
