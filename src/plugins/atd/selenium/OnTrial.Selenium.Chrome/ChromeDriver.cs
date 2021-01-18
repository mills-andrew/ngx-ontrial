namespace OnTrial.Selenium.Chrome
{
    public partial class ChromeDriver : WebAgent
    {
        public ChromeDriver(string pId) : this(pId, new ChromeOptions(), new ChromeService()) { }
        public ChromeDriver(string pId, ChromeService pService) : this(pId, new ChromeOptions(), pService) { }
        public ChromeDriver(string pId, ChromeOptions pOptions) : this(pId, pOptions, new ChromeService()) { }
        public ChromeDriver(string pId, ChromeOptions pOptions, ChromeService pService) : base(pId, pOptions, pService) 
        {
            base.mDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            base.Build();
        }
    }
}
