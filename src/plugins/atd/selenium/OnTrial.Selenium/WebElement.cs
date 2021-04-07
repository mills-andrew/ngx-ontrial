using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace OnTrial.Selenium
{
    public class WebElement : Web.IWebElement
    {
        public string Id { get; set; }

        public Size Size => element.Size;

        public Point Location => element.Location;

        public bool IsSelected => element.Selected;

        public string Text => element.Text;

        public string TagName => element.TagName;

        public Rectangle Rect => new Rectangle(element.Location, element.Size);

        public bool IsEnabled => element.Enabled;

        private IWebDriver driver;
        private IWebElement element;

        public WebElement(IWebDriver pDriver, IWebElement pElement)
        {
            this.driver = pDriver;
            this.element = pElement;

            Regex rx = new Regex(@"(\{){0,1}[a-z]{7}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}");
            this.Id = rx.Split(this.element.ToString())[0];
        }

        public void Clear() => element.Clear();

        public void Click() => element.Click();

        public string GetAttribute(string pValue) => element.GetAttribute(pValue);

        public string GetCssValue(string pValue) => element.GetCssValue(pValue);

        public string GetProperty(string pValue) => element.GetProperty(pValue);

        public void SendKeys(string pText) => element.SendKeys(pText);

        public byte[] TakeScreenshot()
        {
            throw new NotSupportedException();
        }

        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }
    }
}
