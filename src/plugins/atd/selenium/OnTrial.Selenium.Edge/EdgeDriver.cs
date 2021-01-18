using OnTrial.Logger;
using System;

namespace OnTrial.Selenium.Edge
{
    public partial class EdgeDriver : WebAgent
    {
        public EdgeDriver(string pId) : this(pId, new EdgeOptions(), new EdgeService()) { }
        public EdgeDriver(string pId, EdgeService pService) : this(pId, new EdgeOptions(), pService) { }
        public EdgeDriver(string pId, EdgeOptions pOptions) : this(pId, pOptions, new EdgeService()) { }
        public EdgeDriver(string pId, EdgeOptions pOptions, EdgeService pService) : base(pId, pOptions, pService)
        {
            try
            {
                base.mDriver = new OpenQA.Selenium.Edge.EdgeDriver();
            }
            catch(Exception e)
            {
                Log.Critical(e.ToString());
            }
            base.Build();
        }
    }
}