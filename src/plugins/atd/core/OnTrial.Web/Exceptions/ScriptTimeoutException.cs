using System;

namespace OnTrial.Web
{
    [Serializable]
    public class ScriptTimeoutException : Exception
    {
        public ScriptTimeoutException(string pMessage) : base(pMessage)
        {
            
        }

        public ScriptTimeoutException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}