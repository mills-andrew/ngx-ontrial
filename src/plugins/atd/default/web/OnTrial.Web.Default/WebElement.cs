using OnTrial.Logger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OnTrial.Web.Default
{
    public class WebElement : IWebElement
    {
        public string Id
        {
            get { return data.Cache<string>("id", () => id); }
            set { id = value; }
        }

        #region Private Variable(s)

        private WebAgent agent;
        private DataCache data;
        private string id;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAgent"></param>
        /// <param name="pId"></param>
        /// <param name="pCacheResults"></param>
        public WebElement(WebAgent pAgent, string pId, bool pCacheResults = false)
        {
            this.agent = pAgent;
            this.id = pId;
            this.data = new DataCache();

            if (pCacheResults == true)
                this.data.CreateCache();
        }

        #endregion

        #region State Method(s)

        /// <summary>
        /// 
        /// </summary>
        public Size Size
        {
            get
            {
                Size size = data.Cache<Size>("size", () => this.agent.ExecuteEndPoint(WebCommand.GetElementRect, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                }));

                return new Size(size.Width, size.Height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point Location
        {
            get
            {
                Point point = data.Cache<Point>("point", () => this.agent.ExecuteEndPoint(WebCommand.GetElementRect, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                }));

                return new Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#is-element-selected"/>
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return data.Cache<bool>("isSelected", () => this.agent.ExecuteEndPoint(WebCommand.IsElementSelected, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                })["value"]);
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-attribute"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetAttribute(string pValue)
        {
            return data.Cache<string>("attribute/", () => this.agent.ExecuteEndPoint(WebCommand.GetElementAttribute, new Dictionary<string, object>()
            {
                { "element id", this.Id },
                { "name", pValue }
            })["value"].ToString());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-property"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetProperty(string pValue)
        {
            return data.Cache<string>("property/", () => this.agent.ExecuteEndPoint(WebCommand.GetElementProperty, new Dictionary<string, object>()
            {
                { "element id", this.Id },
                { "name", pValue }
            })["value"]?.ToString());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-css-value"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetCssValue(string pValue)
        {
            return data.Cache<string>("css/", () => this.agent.ExecuteEndPoint(WebCommand.GetElementCssValue, new Dictionary<string, object>()
            {
                { "element id", this.Id },
                { "name", pValue }
            })["value"]?.ToString());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-text"/>
        /// </summary>
        public string Text
        {
            get
            {
                return data.Cache<string>("text", () => this.agent.ExecuteEndPoint(WebCommand.GetElementText, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                })["value"]?.ToString());
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-tag-name"/>
        /// </summary>
        public string TagName
        {
            get
            {
                return data.Cache<string>("tagname", () => this.agent.ExecuteEndPoint(WebCommand.GetElementTagName, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                }));
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-rect"/>
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                Rectangle rect = data.Cache<Rectangle>("rect", () => this.agent.ExecuteEndPoint(WebCommand.GetElementRect, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                }));

                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#is-element-enabled"/>
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return data.Cache<bool>("enabled", () => this.agent.ExecuteEndPoint(WebCommand.IsElementEnabled, new Dictionary<string, object>()
                {
                    { "element id", this.Id }
                }));
            }
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-click"/>
        /// </summary>
        public void Click()
        {
            this.agent.ExecuteEndPoint(WebCommand.ElementClick, new Dictionary<string, object>()
            {
                { "element id", this.Id }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-clear"/>
        /// </summary>
        public void Clear()
        {
            this.agent.ExecuteEndPoint(WebCommand.ElementClear, new Dictionary<string, object>()
            {
                { "element id", this.Id }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-send-keys"/>
        /// </summary>
        /// <param name="pText"></param>
        public void SendKeys(string pText)
        {
            this.agent.ExecuteEndPoint(WebCommand.ElementSendKeys, new Dictionary<string, object>()
            {
                { "element id", this.Id },
                { "text", pText },
                { "value", pText.ToCharArray() }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#take-element-screenshot"/>
        /// </summary>
        /// <param name="pElement"></param>
        /// <returns></returns>
        public byte[] TakeScreenshot(IWebElement pElement)
        {
            Log.Information("Taking screenshot...");
            return Encoding.ASCII.GetBytes(this.agent.ExecuteEndPoint(WebCommand.TakeElementScreenshot, new Dictionary<string, object>()
            {
                { "id", pElement.Id }
            })["value"].ToString());
        }

        #endregion

        #region Conversion Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                { IWebElement.KeyId, this.Id }
            };
        }

        #endregion
    }
}
