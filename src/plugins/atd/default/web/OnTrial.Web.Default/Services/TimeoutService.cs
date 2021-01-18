using System;
using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#timeouts"/>
    /// </summary>
    public class TimeoutService : ITimeoutService
    {
        public TimeSpan ImplicitWait
        {
            get { return this.getTimeout("implicit"); }
            set { this.setTimeout("implicit", value, TimeSpan.FromSeconds(0)); }
        }

        public TimeSpan PageLoad
        {
            get { return this.getTimeout("pageLoad"); }
            set { this.setTimeout("pageLoad", value, TimeSpan.FromSeconds(300)); }
        }

        public TimeSpan AsyncJavaScriptWait
        {
            get { return this.getTimeout("script"); }
            set { this.setTimeout("script", value, TimeSpan.FromSeconds(30)); }
        }

        #region Constructor(s)

        protected WebAgent mAgent { get; set; }
        public TimeoutService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
        }

        #endregion

        #region Private Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-timeouts"/>
        /// </summary>
        /// <param name="pTimeoutName"></param>
        /// <returns></returns>
        private TimeSpan getTimeout(string pTimeoutName)
        {
            var response = this.mAgent.ExecuteEndPoint(WebCommand.GetTimeouts)[pTimeoutName];
            return TimeSpan.FromMilliseconds(Convert.ToDouble(response));
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#set-timeouts"/>
        /// </summary>
        /// <param name="pTimeoutName"></param>
        /// <param name="pTimeout"></param>
        /// <param name="pDefault"></param>
        /// <returns></returns>
        private object setTimeout(string pTimeoutName, TimeSpan pTimeout, TimeSpan pDefault)
        {
            if (pTimeout == TimeSpan.MinValue)
                pTimeout = pDefault;

            return this.mAgent.ExecuteEndPoint(WebCommand.SetTimeouts, new Dictionary<string, object>()
            {
                { pTimeoutName, Convert.ToInt64(pTimeout.TotalMilliseconds) }
            });
        }

        #endregion
    }
}
