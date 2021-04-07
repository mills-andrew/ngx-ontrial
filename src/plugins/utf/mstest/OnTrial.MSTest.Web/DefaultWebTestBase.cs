using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;
using OnTrial.Logger;
using OnTrial.Web;
using OnTrial.Workflow.Web;
using System.Linq;

namespace OnTrial.MSTest.Web
{
    [TestSuite]
    public class DefaultWebTestBase : MSTestBase
    {
        protected IWebAgent mAgent;

        public override void FrameworkInitialize()
        {
            Framework.Construct()
                .AddDefaultConfiguration()
                .AddConsoleLogger()
                .AddMSTestAssert()
                .Build();

            string webType = Context.Properties["atd.web.type"]?.ToString() ?? "default";
            if (webType == "selenium")
                Framework.Construct().UseSeleniumWebBehavior().Build();
            else if (webType == "default")
                Framework.Construct().UseDefaultWebBehavior().Build();
            else
            {
                Log.Warning("Could not identify the defined automation test driver. Using default.");
                Framework.Construct().UseDefaultWebBehavior().Build();
            }
        }

        public override void TestCaseInitialize()
        {
            mAgent = Framework.Provider.GetServices<IWebAgent>().First(m => m.Id == Context.FullTestName);
        }
    }
}
