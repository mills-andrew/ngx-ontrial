using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop
{
    [Serializable]
    public class InsecureCertificateException : Exception
    {
        public InsecureCertificateException(string pMessage) : base(pMessage)
        {

        }

        public InsecureCertificateException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException)
        {

        }
    }
}
