using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class MoveTargetoutofBoundsException : Exception
    {
        public MoveTargetoutofBoundsException(string pMessage) : base(pMessage)
        {

        }

        public MoveTargetoutofBoundsException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
