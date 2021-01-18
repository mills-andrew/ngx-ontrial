using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
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
