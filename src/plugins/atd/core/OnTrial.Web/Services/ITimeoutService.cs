using System;

namespace OnTrial.Web
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#timeouts"/>
    /// </summary>
    public interface ITimeoutService
    {
        TimeSpan ImplicitWait { get; set; }
        TimeSpan PageLoad { get; set; }
        TimeSpan AsyncJavaScriptWait { get; set; }
    }
}
