using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OnTrial.Web
{
    [DebuggerDisplay("BrowserAttribute")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BrowserAttribute : Attribute
    {
        public BrowserType Browser { get; }
        public OSPlatform Platform { get; set; }

        public BrowserAttribute(BrowserType browser)
        {
            Browser = browser;
        }
    }
}
