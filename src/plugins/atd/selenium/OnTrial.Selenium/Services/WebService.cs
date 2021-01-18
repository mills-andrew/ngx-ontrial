using OnTrial.Api;
using OnTrial.Web;
using OpenQA.Selenium;
using System;

namespace OnTrial.Selenium
{
    public class WebService : IWebService
    {
        public ApiClient Client { get; set; }
        public string Arguments { get; set; }
        public string HostName { get; set; }
        public string ServicePath { get; set; }
        public string ExecutableName { get; set; }
        public int Port { get; set; }
        public IProtocolService Protocol { get; set; }

        protected IWebDriver mDriver;
        public WebService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        public void BuildArguments()
        {
            throw new NotSupportedException();
        }

        public void Start()
        {
            throw new NotSupportedException();
        }

        public void Stop()
        {
            mDriver.Quit();
        }
    }
}
