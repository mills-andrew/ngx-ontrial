using System;

namespace OnTrial.Web
{
    [Serializable]
    public class SessionNotCreatedException : Exception
    {
        public SessionNotCreatedException(string pMessage) : base(pMessage)
        {
            
        }

        public SessionNotCreatedException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}