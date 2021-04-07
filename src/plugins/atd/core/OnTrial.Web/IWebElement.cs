using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Web
{
    public interface IWebElement
    {
        public static string KeyId = "element-6066-11e4-a52e-4f735466cecf";
        public string Id { get; set; }

        #region State Method(s)

        /// <summary>
        /// 
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// 
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#is-element-selected"/>
        /// </summary>
        public bool IsSelected { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-attribute"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetAttribute(string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-property"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetProperty(string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-css-value"/>
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string GetCssValue(string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-text"/>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-tag-name"/>
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-element-rect"/>
        /// </summary>
        public Rectangle Rect { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#is-element-enabled"/>
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-click"/>
        /// </summary>
        public void Click();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-clear"/>
        /// </summary>
        public void Clear();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#element-send-keys"/>
        /// </summary>
        /// <param name="pText"></param>
        public void SendKeys(string pText);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#take-element-screenshot"/>
        /// </summary>
        /// <returns></returns>
        public byte[] TakeScreenshot();

        #endregion

        #region Conversion Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary();

        #endregion
    }
}
