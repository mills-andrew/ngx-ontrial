using System;
using System.Collections.Generic;
using OnTrial.Api;
using OnTrial.Web;

namespace OnTrial.Selenium
{
    public class ProtocolService : IProtocolService
    {
        public Dictionary<object, EndPoint> EndPoints { get; set; }
        public Dictionary<object, Type> Exceptions { get; set; }
        public Dictionary<object, string> Locators { get; set; }

        /// <summary>
        /// Implement the the W3C protocol defined by <see cref="https://www.w3.org/TR/webdriver/"/>
        /// </summary>
        public void BuildW3CProtocol()
        {
            #region Locators

            #endregion

            #region EndPoints

            #endregion

            #region Exceptions

            #endregion
        }
    }
}
