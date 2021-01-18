using System.Collections.Generic;

namespace OnTrial.Web.Default.Chrome
{
    public partial class ChromeDriver : WebAgent
    {
        public ChromeDriver(string pId) : this(pId, new ChromeOptions(), new ChromeService()) { }
        public ChromeDriver(string pId, ChromeService pService) : this(pId, new ChromeOptions(), pService) { }
        public ChromeDriver(string pId, ChromeOptions pOptions) : this(pId, pOptions, new ChromeService()) { }
        public ChromeDriver(string pId, ChromeOptions pOptions, ChromeService pService) : base(pId, pOptions, pService) 
        {
            base.Build();
        }

        public void ExecuteChromeCommand(string pName, Dictionary<string, object> pParams)
        {
            base.ExecuteEndPoint(ChromeCommand.SendChromeCommand, new Dictionary<string, object>()
            {
                { "cmd", pName },
                { "params", pParams }
            });
        }
    }
}
