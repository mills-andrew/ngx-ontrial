using OpenQA.Selenium;

namespace OnTrial.Selenium.Edge
{
    public class EdgeService : WebService
    {
        public EdgeService() : this(null) { }
        public EdgeService(IWebDriver pDriver) : base(pDriver)
        {
        }
    }
}
