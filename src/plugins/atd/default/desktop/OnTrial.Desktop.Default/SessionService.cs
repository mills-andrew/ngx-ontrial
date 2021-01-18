using OnTrial.Logger;
using System;
using System.Collections.Generic;

namespace OnTrial.Desktop.Default
{
    public class SessionService : ISessionService
    {
        public string Id { get; set; }
        
        protected DesktopDriver mDriver;
        public SessionService(DesktopDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        public void NewSession()
        {
            Log.Information("Starting Session");
            IDictionary<string, object> response = mDriver.ExecuteEndPoint(DesktopCommand.NewSession, new Dictionary<string, object>()
            {
                { "desiredCapabilities", mDriver.Options.ToCapabilities() }
            });
            this.Id = response["sessionId"].ToString();
        }

        public void DeleteSession()
        {
            Log.Information("Deleting Session");
            mDriver.ExecuteEndPoint(DesktopCommand.DeleteSession);
            this.Id = null;
        }
    }
}
