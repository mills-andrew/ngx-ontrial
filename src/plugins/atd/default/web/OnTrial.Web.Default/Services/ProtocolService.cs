using OnTrial.Api;
using System;
using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    public class ProtocolService : IProtocolService
    {
        public Dictionary<object, EndPoint> EndPoints { get; set; }
        public Dictionary<object, Type> Exceptions { get; set; }
        public Dictionary<object, string> Locators { get; set; }

        public void BuildW3CProtocol()
        {
            #region Locators

            this.Locators = new Dictionary<object, string>();
            this.Locators.Add(WebLocator.Css, "css selector");
            this.Locators.Add(WebLocator.LinkText, "link text");
            this.Locators.Add(WebLocator.PartialLinkText, "partial link text");
            this.Locators.Add(WebLocator.TagName, "css selector");
            this.Locators.Add(WebLocator.XPath, "xpath");

            #endregion

            #region EndPoints

            this.EndPoints = new Dictionary<object, EndPoint>();
            this.EndPoints.Add(WebCommand.NewSession, new EndPoint(ApiMethod.Post, "/session"));
            this.EndPoints.Add(WebCommand.DeleteSession, new EndPoint(ApiMethod.Delete, "/session/{session id}"));
            this.EndPoints.Add(WebCommand.Status, new EndPoint(ApiMethod.Get, "/status"));
            this.EndPoints.Add(WebCommand.GetTimeouts, new EndPoint(ApiMethod.Get, "/session/{session id}/timeouts"));
            this.EndPoints.Add(WebCommand.SetTimeouts, new EndPoint(ApiMethod.Post, "/session/{session id}/timeouts"));
            this.EndPoints.Add(WebCommand.NavigateTo, new EndPoint(ApiMethod.Post, "/session/{session id}/url"));
            this.EndPoints.Add(WebCommand.GetCurrentUrl, new EndPoint(ApiMethod.Get, "/session/{session id}/url"));
            this.EndPoints.Add(WebCommand.Back, new EndPoint(ApiMethod.Post, "/session/{session id}/back"));
            this.EndPoints.Add(WebCommand.Forward, new EndPoint(ApiMethod.Post, "/session/{session id}/forward"));
            this.EndPoints.Add(WebCommand.Refresh, new EndPoint(ApiMethod.Post, "/session/{session id}/refresh"));
            this.EndPoints.Add(WebCommand.GetTitle, new EndPoint(ApiMethod.Get, "/session/{session id}/title"));
            this.EndPoints.Add(WebCommand.GetWindowHandle, new EndPoint(ApiMethod.Get, "/session/{session id}/window"));
            this.EndPoints.Add(WebCommand.CloseWindow, new EndPoint(ApiMethod.Delete, "/session/{session id}/window"));
            this.EndPoints.Add(WebCommand.SwitchToWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window"));
            this.EndPoints.Add(WebCommand.GetWindowHandles, new EndPoint(ApiMethod.Get, "/session/{session id}/window/handles"));
            this.EndPoints.Add(WebCommand.NewWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window/new"));
            this.EndPoints.Add(WebCommand.SwitchToFrame, new EndPoint(ApiMethod.Post, "/session/{session id}/frame"));
            this.EndPoints.Add(WebCommand.SwitchToParentFrame, new EndPoint(ApiMethod.Post, "/session/{session id}/frame/parent"));
            this.EndPoints.Add(WebCommand.GetWindowRect, new EndPoint(ApiMethod.Get, "/session/{session id}/window/rect"));
            this.EndPoints.Add(WebCommand.SetWindowRect, new EndPoint(ApiMethod.Post, "/session/{session id}/window/rect"));
            this.EndPoints.Add(WebCommand.MaximizeWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window/maximize"));
            this.EndPoints.Add(WebCommand.MinimizeWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window/minimize"));
            this.EndPoints.Add(WebCommand.FullscreenWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window/fullscreen"));
            this.EndPoints.Add(WebCommand.GetActiveElement, new EndPoint(ApiMethod.Get, "/session/{session id}/element/active"));
            this.EndPoints.Add(WebCommand.FindElement, new EndPoint(ApiMethod.Post, "/session/{session id}/element"));
            this.EndPoints.Add(WebCommand.FindElements, new EndPoint(ApiMethod.Post, "/session/{session id}/elements"));
            this.EndPoints.Add(WebCommand.FindElementFromElement, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/element"));
            this.EndPoints.Add(WebCommand.FindElementsFromElement, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/elements"));
            this.EndPoints.Add(WebCommand.IsElementSelected, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/selected"));
            this.EndPoints.Add(WebCommand.GetElementAttribute, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/attribute/{name}"));
            this.EndPoints.Add(WebCommand.GetElementProperty, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/property/{name}"));
            this.EndPoints.Add(WebCommand.GetElementCssValue, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/css/{property name}"));
            this.EndPoints.Add(WebCommand.GetElementText, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/text"));
            this.EndPoints.Add(WebCommand.GetElementTagName, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/name"));
            this.EndPoints.Add(WebCommand.GetElementRect, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/rect"));
            this.EndPoints.Add(WebCommand.IsElementEnabled, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/enabled"));
            this.EndPoints.Add(WebCommand.ElementClick, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/click"));
            this.EndPoints.Add(WebCommand.ElementClear, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/clear"));
            this.EndPoints.Add(WebCommand.ElementSendKeys, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/value"));
            this.EndPoints.Add(WebCommand.GetPageSource, new EndPoint(ApiMethod.Get, "/session/{session id}/source"));
            this.EndPoints.Add(WebCommand.ExecuteScript, new EndPoint(ApiMethod.Post, "/session/{session id}/execute/sync"));
            this.EndPoints.Add(WebCommand.ExecuteAsyncScript, new EndPoint(ApiMethod.Post, "/session/{session id}/execute/async"));
            this.EndPoints.Add(WebCommand.GetAllCookies, new EndPoint(ApiMethod.Get, "/session/{session id}/cookie"));
            this.EndPoints.Add(WebCommand.GetNamedCookie, new EndPoint(ApiMethod.Get, "/session/{session id}/cookie/{name}"));
            this.EndPoints.Add(WebCommand.AddCookie, new EndPoint(ApiMethod.Post, "/session/{session id}/cookie"));
            this.EndPoints.Add(WebCommand.DeleteCookie, new EndPoint(ApiMethod.Delete, "/session/{session id}/cookie/{name}"));
            this.EndPoints.Add(WebCommand.DeleteAllCookies, new EndPoint(ApiMethod.Delete, "/session/{session id}/cookie"));
            this.EndPoints.Add(WebCommand.PerformActions, new EndPoint(ApiMethod.Post, "/session/{session id}/actions"));
            this.EndPoints.Add(WebCommand.ReleaseActions, new EndPoint(ApiMethod.Delete, "/session/{session id}/actions"));
            this.EndPoints.Add(WebCommand.DismissAlert, new EndPoint(ApiMethod.Post, "/session/{session id}/alert/dismiss"));
            this.EndPoints.Add(WebCommand.AcceptAlert, new EndPoint(ApiMethod.Post, "/session/{session id}/alert/accept"));
            this.EndPoints.Add(WebCommand.GetAlertText, new EndPoint(ApiMethod.Get, "/session/{session id}/alert/text"));
            this.EndPoints.Add(WebCommand.SendAlertText, new EndPoint(ApiMethod.Post, "/session/{session id}/alert/text"));
            this.EndPoints.Add(WebCommand.TakeScreenshot, new EndPoint(ApiMethod.Get, "/session/{session id}/screenshot"));
            this.EndPoints.Add(WebCommand.TakeElementScreenshot, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/screenshot"));

            #endregion

            #region Exceptions

            this.Exceptions = new Dictionary<object, Type>();

            this.Exceptions.Add("element click intercepted", typeof(ElementClickInterceptedException));
            this.Exceptions.Add("element not interactable", typeof(ElementNotInteractableException));
            this.Exceptions.Add("insecure certificate", typeof(InsecureCertificateException));
            this.Exceptions.Add("invalid argument", typeof(InvalidArgumentException));
            this.Exceptions.Add("invalid cookie domain", typeof(InvalidCookieDomainException));
            this.Exceptions.Add("invalid element state", typeof(InvalidElementStateException));
            this.Exceptions.Add("invalid selector", typeof(InvalidSelectorException));
            this.Exceptions.Add("invalid session id", typeof(InvalidSessionIdException));
            this.Exceptions.Add("javascript error", typeof(JavascriptErrorException));
            this.Exceptions.Add("move target out of bounds", typeof(MoveTargetOutOfBoundsException));
            this.Exceptions.Add("no such alert", typeof(NoSuchAlertException));
            this.Exceptions.Add("no such cookie", typeof(NoSuchCookieException));
            this.Exceptions.Add("no such element", typeof(NoSuchElementException));
            this.Exceptions.Add("no such frame", typeof(NoSuchFrameException));
            this.Exceptions.Add("no such window", typeof(NoSuchWindowException));
            this.Exceptions.Add("script timeout", typeof(ScriptTimeoutException));
            this.Exceptions.Add("session not created", typeof(SessionNotCreatedException));
            this.Exceptions.Add("stale element reference", typeof(StaleElementReferenceException));
            this.Exceptions.Add("timeout", typeof(TimeoutException));
            this.Exceptions.Add("unable to set cookie", typeof(UnableToSetCookieException));
            this.Exceptions.Add("unable to capture screen", typeof(UnableToCaptureScreenException));
            this.Exceptions.Add("unexpected alert open", typeof(UnexpectedAlertOpenException));
            this.Exceptions.Add("unknown command", typeof(UnknownCommandException));
            this.Exceptions.Add("unknown error", typeof(UnknownErrorException));
            this.Exceptions.Add("unknown method", typeof(UnknownMethodException));
            this.Exceptions.Add("unsupported operation", typeof(UnsupportedOperationException));

            #endregion
        }
    }
}
