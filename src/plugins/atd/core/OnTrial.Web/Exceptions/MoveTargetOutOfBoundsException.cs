using System;

namespace OnTrial.Web
{
    [Serializable]
    public class MoveTargetOutOfBoundsException : Exception
    {
        public MoveTargetOutOfBoundsException(string pMessage) : base(pMessage)
        {
            
        }

        public MoveTargetOutOfBoundsException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {
            
        }
    }
}