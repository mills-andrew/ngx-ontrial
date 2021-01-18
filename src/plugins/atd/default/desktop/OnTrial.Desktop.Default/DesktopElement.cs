using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OnTrial.Desktop.Default
{
    public class DesktopElement : IDesktopElement
    {
        public string Id { get; set; }
        
        public string IsActive
        {
            get
            {
                return this.mDriver.ExecuteEndPoint(DesktopCommand.GetActiveElement, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                })["value"].ToString();
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.mDriver.ExecuteEndPoint(DesktopCommand.IsElementSelected, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                })["value"].ToBoolean();
            }
        }

        public string Text
        {
            get
            {
                return this.mDriver.ExecuteEndPoint(DesktopCommand.GetElementText, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                })["value"].ToString();
            }
        }

        public string TagName => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public bool IsEnabled => throw new NotImplementedException();

        public Rectangle Rect => throw new NotImplementedException();

        protected DesktopDriver mDriver;
        public DesktopElement(DesktopDriver pDriver, string pId, bool pCacheResults = false)
        {
            this.mDriver = pDriver;
            this.Id = pId;
        }

        public void Click()
        {
            this.mDriver.ExecuteEndPoint(DesktopCommand.ElementClick, new Dictionary<string, object>()
            {
                { "element id", this.Id }
            });
        }

        public void SendKeys(string pText)
        {
            if (IsSelected == false)
                this.Click();

            this.mDriver.ExecuteEndPoint(DesktopCommand.SendKeys, new Dictionary<string, object>()
            {
                { "value", pText.ToCharArray() }
            });
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string pValue)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string pValue)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string pValue)
        {
            throw new NotImplementedException();
        }
    }
}
