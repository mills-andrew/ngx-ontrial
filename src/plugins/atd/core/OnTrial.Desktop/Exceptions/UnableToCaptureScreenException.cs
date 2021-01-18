using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class UnableToCaptureScreenException : Exception
    {
        public UnableToCaptureScreenException(string pMessage) : base(pMessage)
        {

        }

        public UnableToCaptureScreenException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
