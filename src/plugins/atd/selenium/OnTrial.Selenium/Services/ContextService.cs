using OnTrial.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Selenium
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#contexts"/>
    /// </summary>
    public class ContextService : IContextService
    {
        protected IWebDriver mDriver;
        public ContextService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Context Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handle"/>
        /// </summary>
        public string GetWindowHandle()
        {
            return mDriver.CurrentWindowHandle;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#close-window"/>
        /// </summary>
        public void CloseWindow()
        {
            mDriver.Close();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-window"/>
        /// </summary>
        public void SwitchToWindow(string pName)
        {
            mDriver.SwitchTo().Window(pName);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handles"/>
        /// </summary>
        public IReadOnlyCollection<object> GetWindowHandles()
        {
            return mDriver.WindowHandles;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-window"/>
        /// </summary>
        public void NewWindow()
        {
            throw new NotSupportedException("Selenium doesn't support direct window creation.");
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        #region Switch To Frame Method(s)

        public void SwitchToFrame()
        {
            mDriver.SwitchTo().Frame(0);
        }

        public void SwitchToFrame(string pFrameName)
        {
            mDriver.SwitchTo().Frame(pFrameName);
        }

        public void SwitchToFrame(int pId)
        {
            mDriver.SwitchTo().Frame(pId);
        }

        public void SwitchToFrame(Web.IWebElement pElement)
        {
            mDriver.SwitchTo().Frame(new RemoteWebElement((RemoteWebDriver)mDriver, pElement.Id));
        }

        #endregion

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-parent-frame"/>
        /// </summary>
        public void SwitchToParentFrame()
        {
            mDriver.SwitchTo().ParentFrame();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-rect"/>
        /// </summary>
        public Rectangle GetWindowRect()
        {
            return new Rectangle(mDriver.Manage().Window.Position, mDriver.Manage().Window.Size);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#set-window-rect"/>
        /// </summary>
        #region SetWindowRect Method(s)

        public void SetWindowRect(Size pSize)
        {
            mDriver.Manage().Window.Size = pSize;
        }

        public void SetWindowRect(Rectangle pRectable)
        {
            mDriver.Manage().Window.Position = new Point(pRectable.X, pRectable.Y);
            mDriver.Manage().Window.Size = new Size(pRectable.Width, pRectable.Height);
        }

        public void SetWindowRect(Point pPoint)
        {
            mDriver.Manage().Window.Position = new Point(pPoint.X, pPoint.Y);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void NewTab()
        {
            throw new NotSupportedException("Selenium doesn't support direct Tab creation.");
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#maximize-window"/>
        /// </summary>
        public void MaximizeWindow()
        {
            mDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#minimize-window"/>
        /// </summary>
        public void MinimizeWindow()
        {
            mDriver.Manage().Window.Minimize();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#fullscreen-window"/>
        /// </summary>
        public void FullscreenWindow()
        {
            mDriver.Manage().Window.FullScreen();
        }

        #endregion
    }
}
