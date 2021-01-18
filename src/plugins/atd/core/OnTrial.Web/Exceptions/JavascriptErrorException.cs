using System;

namespace OnTrial.Web
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