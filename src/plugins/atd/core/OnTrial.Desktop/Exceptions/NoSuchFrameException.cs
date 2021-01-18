using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class NoSuchFrameException : Exception
    {
        public NoSuchFrameException(string pMessage) : base(pMessage)
        {

        }

        public NoSuchFrameException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
