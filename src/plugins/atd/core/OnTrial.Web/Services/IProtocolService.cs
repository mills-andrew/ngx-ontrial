using System;
using System.Collections.Generic;
using OnTrial.Api;

namespace OnTrial.Web
{
    public interface IProtocolService
    {
        Dictionary<object, EndPoint> EndPoints { get; set; }
        Dictionary<object, Type> Exceptions { get; set; }
        Dictionary<object, string> Locators { get; set; }

        /// <summary>
        /// Implement the the W3C protocol defined by <see cref="https://www.w3.org/TR/webdriver/"/>
        /// </summary>
        void BuildW3CProtocol();
    }
}
