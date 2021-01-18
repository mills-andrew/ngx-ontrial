using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InvalidSessionIdException : Exception
    {
        public InvalidSessionIdException(string pMessage) : base(pMessage)
        {

        }

        public InvalidSessionIdException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
