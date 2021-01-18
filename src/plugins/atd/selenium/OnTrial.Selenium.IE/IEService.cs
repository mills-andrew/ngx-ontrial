using OpenQA.Selenium;

namespace OnTrial.Selenium.IE
{
    public class IEService : WebService
    {
        public IEService() : this(null) { }
        public IEService(IWebDriver pDriver) : base(pDriver)
        {
        }
    }
}
