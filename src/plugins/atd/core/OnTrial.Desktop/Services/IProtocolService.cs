using OnTrial.Api;
using System;
using System.Collections.Generic;

namespace OnTrial.Desktop
{
    public interface IProtocolService
    {
        public Dictionary<object, EndPoint> EndPoints { get; set; }
        public Dictionary<object, Type> Exceptions { get; set; }
        public Dictionary<object, string> Locators { get; set; }

        public void BuildW3CProtocol();
    }
}
