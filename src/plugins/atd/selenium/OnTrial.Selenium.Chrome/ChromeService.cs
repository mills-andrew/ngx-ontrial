using OpenQA.Selenium;

namespace OnTrial.Selenium.Chrome
{
    public class ChromeService : WebService
    {
        public ChromeService() : this(null) { }
        public ChromeService(IWebDriver pDriver) : base(pDriver)
        {
        }
    }
}