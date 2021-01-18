using System.Collections.Generic;

namespace OnTrial.Web.Default.Edge
{
    public partial class EdgeDriver : WebAgent
    {
        public EdgeDriver(string pId) : this(pId, new EdgeOptions(), new EdgeService()) { }
        public EdgeDriver(string pId, EdgeService pService) : this(pId, new EdgeOptions(), pService) { }
        public EdgeDriver(string pId, EdgeOptions pOptions) : this(pId, pOptions, new EdgeService()) { }
        public EdgeDriver(string pId, EdgeOptions pOptions, EdgeService pService) : base(pId, pOptions, pService) 
        {
            base.Build();
        }

        public void ExecuteEdgeCommand(string pName, Dictionary<string, object> pParams)
        {
            
        }
    }
}
