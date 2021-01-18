using OnTrial.Logger;
using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    public class SessionService : ISessionService
    {
        public string Id { get; set; }

        #region Constructor(s)

        protected WebAgent mAgent;
        public SessionService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
        }

        #endregion
        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        public void NewSession()
        {
            Log.Information("Creating a new session...");
            IDictionary<string, object> response = mAgent.ExecuteEndPoint(WebCommand.NewSession, new Dictionary<string, object>()
            {
                { "capabilities", new Dictionary<string, object>() {{"firstMatch", new List<object>() { mAgent.Capabilities } }} }
            });
            this.Id = response["sessionId"].ToString();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        public void DeleteSession()
        {
            Log.Information("Deleting session...");
            mAgent.ExecuteEndPoint(WebCommand.DeleteSession);
            this.Id = null;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#status"/>
        /// </summary>
        /// <returns></returns>
        public bool Status()
        {
            Log.Information("Checking status of session...");
            return mAgent.ExecuteEndPoint(WebCommand.NewSession, new Dictionary<string, object>()
            {
                { "capabilities", new Dictionary<string, object>() {{"firstMatch", new List<object>() { mAgent.Capabilities } }} }
            })["value"].ToBoolean();
        }
    }
}
