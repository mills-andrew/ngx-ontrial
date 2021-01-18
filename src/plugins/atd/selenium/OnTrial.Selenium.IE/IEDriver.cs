namespace OnTrial.Selenium.IE
{
    public partial class IEDriver : WebAgent
    {
        public IEDriver(string pId) : this(pId, new IEOptions(), new IEService()) { }
        public IEDriver(string pId, IEService pService) : this(pId, new IEOptions(), pService) { }
        public IEDriver(string pId, IEOptions pOptions) : this(pId, pOptions, new IEService()) { }
        public IEDriver(string pId, IEOptions pOptions, IEService pService) : base(pId, pOptions, pService)
        {
            base.mDriver = new OpenQA.Selenium.IE.InternetExplorerDriver();
            base.Build();
        }
    }
}