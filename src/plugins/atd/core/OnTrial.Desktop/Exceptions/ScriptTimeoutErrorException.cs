using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class ScriptTimeoutErrorException : Exception
    {
        public ScriptTimeoutErrorException(string pMessage) : base(pMessage)
        {

        }

        public ScriptTimeoutErrorException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
