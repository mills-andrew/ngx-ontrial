using OnTrial.Api;

namespace OnTrial.Web.Default.Chrome
{
    public class ChromeProtocol : ProtocolService
    {
        public ChromeProtocol()
        {
            base.BuildW3CProtocol();
            this.EndPoints.Add(ChromeCommand.SendChromeCommand, new EndPoint(ApiMethod.Post, "/session/{session id}/chromium/send_command"));
        }
    }
}
