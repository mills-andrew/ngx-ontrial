using OnTrial.Api;
using System;
using System.Collections.Generic;

namespace OnTrial.Desktop.Default
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
            this.Locators.Add(DesktopLocator.Id, "id");
            this.Locators.Add(DesktopLocator.ClassName, "class name");
            this.Locators.Add(DesktopLocator.TagName, "tag name");
            this.Locators.Add(DesktopLocator.AccessibilityId, "accessibility id");
            this.Locators.Add(DesktopLocator.Name, "name");
            this.Locators.Add(DesktopLocator.UIAutomation, "-windows uiautomation");
            this.Locators.Add(DesktopLocator.XPath, "xpath");

            #endregion

            #region EndPoints

            this.EndPoints = new Dictionary<object, EndPoint>();
            this.EndPoints.Add(DesktopCommand.Status, new EndPoint(ApiMethod.Get, "/status"));
            this.EndPoints.Add(DesktopCommand.NewSession, new EndPoint(ApiMethod.Post, "/session"));
            this.EndPoints.Add(DesktopCommand.Sessions, new EndPoint(ApiMethod.Get, "/sessions"));
            this.EndPoints.Add(DesktopCommand.DeleteSession, new EndPoint(ApiMethod.Delete, "/session/{session id}"));
            this.EndPoints.Add(DesktopCommand.Open, new EndPoint(ApiMethod.Post, "/session/{session id}/appium/app/launch"));
            this.EndPoints.Add(DesktopCommand.Close, new EndPoint(ApiMethod.Post, "/session/{session id}/appium/app/close"));
            this.EndPoints.Add(DesktopCommand.Back, new EndPoint(ApiMethod.Post, "/session/{session id}/back"));
            this.EndPoints.Add(DesktopCommand.ButtonDown, new EndPoint(ApiMethod.Post, "/session/{session id}/buttondown"));
            this.EndPoints.Add(DesktopCommand.ButtonUp, new EndPoint(ApiMethod.Post, "/session/{session id}/buttonup"));
            this.EndPoints.Add(DesktopCommand.Click, new EndPoint(ApiMethod.Post, "/session/{session id}/click"));
            this.EndPoints.Add(DesktopCommand.DoubleClick, new EndPoint(ApiMethod.Post, "/session/{session id}/doubleclick"));
            this.EndPoints.Add(DesktopCommand.FindElement, new EndPoint(ApiMethod.Post, "/session/{session id}/element"));
            this.EndPoints.Add(DesktopCommand.FindElements, new EndPoint(ApiMethod.Post, "/session/{session id}/elements"));
            this.EndPoints.Add(DesktopCommand.GetActiveElement, new EndPoint(ApiMethod.Post, "/session/{session id}/element/active"));
            this.EndPoints.Add(DesktopCommand.GetElementAttribute, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/attribute/:name"));
            this.EndPoints.Add(DesktopCommand.ElementClear, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/clear"));
            this.EndPoints.Add(DesktopCommand.ElementClick, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/click"));
            this.EndPoints.Add(DesktopCommand.ElementSendKeys, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/keys"));
            this.EndPoints.Add(DesktopCommand.IsElementDisplayed, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/displayed"));
            this.EndPoints.Add(DesktopCommand.FindElementFromElement, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/element"));
            this.EndPoints.Add(DesktopCommand.FindElementsFromElement, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/elements"));
            this.EndPoints.Add(DesktopCommand.IsElementEnabled, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/enabled"));
            this.EndPoints.Add(DesktopCommand.ElementEquals, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/equals"));
            this.EndPoints.Add(DesktopCommand.ElementLocation, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/location"));
            this.EndPoints.Add(DesktopCommand.ElementViewLocation, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/location_in_view"));
            this.EndPoints.Add(DesktopCommand.GetElementName, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/name"));
            this.EndPoints.Add(DesktopCommand.TakeElementScreenshot, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/screenshot"));
            this.EndPoints.Add(DesktopCommand.IsElementSelected, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/selected"));
            this.EndPoints.Add(DesktopCommand.GetElementSize, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/size"));
            this.EndPoints.Add(DesktopCommand.GetElementText, new EndPoint(ApiMethod.Get, "/session/{session id}/element/{element id}/text"));
            this.EndPoints.Add(DesktopCommand.GetElementValue, new EndPoint(ApiMethod.Post, "/session/{session id}/element/{element id}/value"));
            this.EndPoints.Add(DesktopCommand.Forward, new EndPoint(ApiMethod.Post, "/session/{session id}/forward"));
            this.EndPoints.Add(DesktopCommand.SendKeys, new EndPoint(ApiMethod.Post, "/session/{session id}/keys"));
            this.EndPoints.Add(DesktopCommand.GetLocation, new EndPoint(ApiMethod.Get, "/session/{session id}/location"));
            this.EndPoints.Add(DesktopCommand.MoveTo, new EndPoint(ApiMethod.Post, "/session/{session id}/moveto"));
            this.EndPoints.Add(DesktopCommand.GetOrientation, new EndPoint(ApiMethod.Get, "/session/{session id}/orientation"));
            this.EndPoints.Add(DesktopCommand.TakeScreenshot, new EndPoint(ApiMethod.Get, "/session/{session id}/screenshot"));
            this.EndPoints.Add(DesktopCommand.GetSource, new EndPoint(ApiMethod.Get, "/session/{session id}/source"));
            this.EndPoints.Add(DesktopCommand.SetTimeouts, new EndPoint(ApiMethod.Post, "/session/{session id}/timeouts"));
            this.EndPoints.Add(DesktopCommand.GetTitle, new EndPoint(ApiMethod.Get, "/session/{session id}/title"));
            //this.EndPoints.Add(CommandType.Tap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/click"));
            //this.EndPoints.Add(CommandType.DoubleTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/doubleclick"));
            //this.EndPoints.Add(CommandType.DownTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/down"));
            //this.EndPoints.Add(CommandType.FlickTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/flick"));
            //this.EndPoints.Add(CommandType.LongTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/longclick"));
            //this.EndPoints.Add(CommandType.MoveTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/move"));
            //this.EndPoints.Add(CommandType.ScrollTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/scroll"));
            //this.EndPoints.Add(CommandType.UpTap, new EndPoint(ApiMethod.Post, "/session/{session id}/touch/up"));
            this.EndPoints.Add(DesktopCommand.CloseWindow, new EndPoint(ApiMethod.Delete, "/session/{session id}/window"));
            this.EndPoints.Add(DesktopCommand.NewWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window"));
            this.EndPoints.Add(DesktopCommand.MaximizeWindow, new EndPoint(ApiMethod.Post, "/session/{session id}/window/maximize"));
            this.EndPoints.Add(DesktopCommand.SetWindowSize, new EndPoint(ApiMethod.Post, "/session/{session id}/window/size"));
            this.EndPoints.Add(DesktopCommand.GetWindowSize, new EndPoint(ApiMethod.Get, "/session/{session id}/window/size"));
            this.EndPoints.Add(DesktopCommand.SetWindowHandlesSize, new EndPoint(ApiMethod.Post, "/session/{session id}/window/:windowHandle/size"));
            this.EndPoints.Add(DesktopCommand.GetWindowHandlesSize, new EndPoint(ApiMethod.Get, "/session/{session id}/window/:windowHandle/size"));
            this.EndPoints.Add(DesktopCommand.SetWindowHandlePosition, new EndPoint(ApiMethod.Post, "/session/{session id}/window/:windowHandle/position"));
            this.EndPoints.Add(DesktopCommand.GetWindowHandlePosition, new EndPoint(ApiMethod.Get, "/session/{session id}/window/:windowHandle/position"));
            this.EndPoints.Add(DesktopCommand.MaximizeWindowHandle, new EndPoint(ApiMethod.Post, "/session/{session id}/window/:windowHandle/maximize"));
            this.EndPoints.Add(DesktopCommand.GetWindowHandle, new EndPoint(ApiMethod.Get, "/session/{session id}/window_handle"));
            this.EndPoints.Add(DesktopCommand.GetWindowHandles, new EndPoint(ApiMethod.Get, "/session/{session id}/window_handles"));

            #endregion

            #region Exceptions

            this.Exceptions = new Dictionary<object, Type>();
            /*
            this.Exceptions.Add("element click intercepted", new Exception("element click intercepted", new Exception("The Element Click command could not be completed because the element receiving the events is obscuring the element that was requested clicked.")));
            this.Exceptions.Add("element not interactable", new Exception("element not interactable", new Exception("A command could not be completed because the element is not pointer- or keyboard interactable.")));
            this.Exceptions.Add("insecure certificate", new Exception("insecure certificate", new Exception("Navigation caused the user agent to hit a certificate warning, which is usually the result of an expired or invalid TLS certificate.")));
            this.Exceptions.Add("invalid argument", new Exception("invalid argument", new Exception("The arguments passed to a command are either invalid or malformed.")));
            this.Exceptions.Add("invalid cookie domain", new Exception("invalid cookie domain", new Exception("An illegal attempt was made to set a cookie under a different domain than the current page.")));
            this.Exceptions.Add("invalid element state", new Exception("invalid element state", new Exception("A command could not be completed because the element is in an invalid state, e.g. attempting to clear an element that isn’t both editable and resettable.")));
            this.Exceptions.Add("invalid selector", new Exception("invalid selector", new Exception("Argument was an invalid selector.")));
            this.Exceptions.Add("invalid session id", new Exception("invalid session id", new Exception("Occurs if the given session id is not in the list of active sessions, meaning the session either does not exist or that it’s not active.")));
            this.Exceptions.Add("javascript error", new Exception("javascript error", new Exception("An error occurred while executing JavaScript supplied by the user.")));
            this.Exceptions.Add("move target out of bounds", new Exception("move target out of bounds", new Exception("The target for mouse interaction is not in the browser’s viewport and cannot be brought into that viewport.")));
            this.Exceptions.Add("no such alert", new Exception("no such alert", new Exception("An attempt was made to operate on a modal dialog when one was not open.")));
            this.Exceptions.Add("no such cookie", new Exception("no such cookie", new Exception("No cookie matching the given path name was found amongst the associated cookies of the current browsing context’s active document.")));
            this.Exceptions.Add("no such element", new Exception("no such element", new Exception("An element could not be located on the page using the given search parameters.")));
            this.Exceptions.Add("no such frame", new Exception("no such frame", new Exception("A command to switch to a frame could not be satisfied because the frame could not be found.")));
            this.Exceptions.Add("no such window", new Exception("no such window", new Exception("A command to switch to a window could not be satisfied because the window could not be found.")));
            this.Exceptions.Add("script timeout", new Exception("script timeout", new Exception("A script did not complete before its timeout expired.")));
            this.Exceptions.Add("session not created", new Exception("session not created", new Exception("A new session could not be created.")));
            this.Exceptions.Add("stale element reference", new Exception("stale element reference", new Exception("A command failed because the referenced element is no longer attached to the DOM.")));
            this.Exceptions.Add("timeout", new Exception("timeout", new Exception("An operation did not complete before its timeout expired.")));
            this.Exceptions.Add("unable to set cookie", new Exception("unable to set cookie", new Exception("A command to set a cookie’s value could not be satisfied.")));
            this.Exceptions.Add("unable to capture screen", new Exception("unable to capture screen", new Exception("A screen capture was made impossible.")));
            this.Exceptions.Add("unexpected alert open", new Exception("unexpected alert open", new Exception("A modal dialog was open, blocking this operation.")));
            this.Exceptions.Add("unknown command", new Exception("unknown command", new Exception("A command could not be executed because the remote end is not aware of it.")));
            this.Exceptions.Add("unknown error", new Exception("unknown error", new Exception("An unknown error occurred in the remote end while processing the command.")));
            this.Exceptions.Add("unknown method", new Exception("unknown method", new Exception("The requested command matched a known URL but did not match an method for that URL.")));
            this.Exceptions.Add("unsupported operation", new Exception("unsupported operation", new Exception("Indicates that a command that should have executed properly cannot be supported for some reason.")));
            */
            #endregion
        }
    }
}
