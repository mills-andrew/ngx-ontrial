using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnTrial.Web.Default
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#contexts"/>
    /// </summary>
    public class ContextService : IContextService
    {
        protected WebAgent mAgent;
        public ContextService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
        }

        #region Context Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handle"/>
        /// </summary>
        public string GetWindowHandle()
        {
            return mAgent.ExecuteEndPoint(WebCommand.GetWindowHandle)["value"].ToString();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#close-window"/>
        /// </summary>
        public void CloseWindow()
        {
            mAgent.ExecuteEndPoint(WebCommand.CloseWindow);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-window"/>
        /// </summary>
        public void SwitchToWindow(string pName)
        {
            mAgent.ExecuteEndPoint(WebCommand.SwitchToWindow, new Dictionary<string, object>
            {
                { "handle", pName }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handles"/>
        /// </summary>
        public IReadOnlyCollection<object> GetWindowHandles()
        {
            return mAgent.ExecuteEndPoint(WebCommand.GetWindowHandles)["value"] as IReadOnlyCollection<object>;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-window"/>
        /// </summary>
        public void NewWindow()
        {
            mAgent.ExecuteEndPoint(WebCommand.NewWindow, new Dictionary<string, object>()
            {
                { "type", "window" }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        #region Switch To Frame Method(s)

        public void SwitchToFrame()
        {
            mAgent.ExecuteEndPoint(WebCommand.SwitchToFrame, new Dictionary<string, object>()
            {
                { "id", null }
            });
        }

        public void SwitchToFrame(string pFrameName)
        {
            if (pFrameName == null)
                throw new ArgumentNullException("pFrameName", "Frame name cannot be null");

            string name = Regex.Replace(pFrameName, @"(['""\\#.:;,!?+<>=~*^$|%&@`{}\-/\[\]\(\)])", @"\$1");
            IReadOnlyCollection<IWebElement> frameElements = this.mAgent.FindElements(WebLocator.Css, "frame[name='" + name + "'],iframe[name='" + name + "']");
            if (frameElements.Count == 0)
            {
                frameElements = this.mAgent.FindElements(WebLocator.Css, "frame#" + name + ",iframe#" + name);
                if (frameElements.Count == 0)
                    throw new Exception("No frame element found with name or id " + pFrameName);
            }

            this.SwitchToFrame(frameElements.ToList()[0]);
        }

        public void SwitchToFrame(int pId)
        {
            mAgent.ExecuteEndPoint(WebCommand.SwitchToFrame, new Dictionary<string, object>()
            {
                { "id", pId }
            });
        }

        public void SwitchToFrame(IWebElement pElement)
        {
            if (pElement is null)
                throw new ArgumentNullException(nameof(pElement));

            mAgent.ExecuteEndPoint(WebCommand.SwitchToFrame, new Dictionary<string, object>()
            {
                { "id", new Dictionary<string, object>()
                {
                    { IWebElement.KeyId, pElement.Id },
                    { "element", pElement.Id } }
                }
            });
        }

        #endregion

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-parent-frame"/>
        /// </summary>
        public void SwitchToParentFrame()
        {
            mAgent.ExecuteEndPoint(WebCommand.SwitchToParentFrame);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-rect"/>
        /// </summary>
        public Rectangle GetWindowRect()
        {
            Dictionary<string, object> response = mAgent.ExecuteEndPoint(WebCommand.GetWindowRect)["value"] as Dictionary<string, object>;
            int x = Convert.ToInt32(response["x"]);
            int y = Convert.ToInt32(response["y"]);
            int width = Convert.ToInt32(response["width"]);
            int height = Convert.ToInt32(response["height"]);
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#set-window-rect"/>
        /// </summary>
        #region SetWindowRect Method(s)

        public void SetWindowRect(Size pSize)
        {
            mAgent.ExecuteEndPoint(WebCommand.SetWindowRect, new Dictionary<string, object>
            {
                { "width", pSize.Width },
                { "height", pSize.Height }
            });
        }

        public void SetWindowRect(Rectangle pRectable)
        {
            mAgent.ExecuteEndPoint(WebCommand.SetWindowRect, new Dictionary<string, object>
            {
                { "x", pRectable.X },
                { "y", pRectable.Y },
                { "width", pRectable.Width },
                { "height", pRectable.Height }
            });
        }

        public void SetWindowRect(Point pPoint)
        {
            mAgent.ExecuteEndPoint(WebCommand.SetWindowRect, new Dictionary<string, object>
            {
                { "x", pPoint.X },
                { "y", pPoint.Y }
            });
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void NewTab()
        {
            mAgent.ExecuteEndPoint(WebCommand.NewWindow, new Dictionary<string, object>()
            {
                { "type", "tab" }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#maximize-window"/>
        /// </summary>
        public void MaximizeWindow()
        {
            mAgent.ExecuteEndPoint(WebCommand.MaximizeWindow);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#minimize-window"/>
        /// </summary>
        public void MinimizeWindow()
        {
            mAgent.ExecuteEndPoint(WebCommand.MinimizeWindow);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#fullscreen-window"/>
        /// </summary>
        public void FullscreenWindow()
        {
            mAgent.ExecuteEndPoint(WebCommand.FullscreenWindow);
        }

        #endregion
    }
}
