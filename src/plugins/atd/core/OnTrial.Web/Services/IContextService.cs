using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Web
{
    public interface IContextService
    {
        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handle"/>
        /// </summary>
        string GetWindowHandle();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#close-window"/>
        /// </summary>
        void CloseWindow();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-window"/>
        /// </summary>
        void SwitchToWindow(string pName);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-handles"/>
        /// </summary>
        IReadOnlyCollection<object> GetWindowHandles();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-window"/>
        /// </summary>
        void NewWindow();

        #region Switch To Frame Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        void SwitchToFrame();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        void SwitchToFrame(string pFrameName);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        void SwitchToFrame(int pId);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-frame"/>
        /// </summary>
        void SwitchToFrame(IWebElement pElement);

        #endregion

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#switch-to-parent-frame"/>
        /// </summary>
        void SwitchToParentFrame();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-window-rect"/>
        /// </summary>
        Rectangle GetWindowRect();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#set-window-rect"/>
        /// </summary>
        #region SetWindowRect Method(s)

        void SetWindowRect(Size pSize);

        void SetWindowRect(Rectangle pRectable);

        void SetWindowRect(Point pPoint);

        #endregion

        /// <summary>
        /// 
        /// </summary>
        void NewTab();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#maximize-window"/>
        /// </summary>
        void MaximizeWindow();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#minimize-window"/>
        /// </summary>
        void MinimizeWindow();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#fullscreen-window"/>
        /// </summary>
        void FullscreenWindow();
    }
}
