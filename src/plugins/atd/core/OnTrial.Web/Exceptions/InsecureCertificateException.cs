using System;

namespace OnTrial.Web
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