using Microsoft.Extensions.DependencyInjection;
using OnTrial.Desktop;
using OnTrial.IOC;
using OnTrial.Logger;
using OnTrial.Workflow.Desktop;
using System.Linq;

namespace OnTrial.MSTest.Desktop
{
    public class DesktopTests : MSTestBase
    {
        protected IDesktopAgent mAgent;

        public override void FrameworkInitialize()
        {
            Framework.Construct()
                .AddDefaultConfiguration()
                .AddConsoleLogger()
                .UseDefaultDesktopBehavior()
                .AddMSTestAssert()
                .Build();
        }

        public override void TestInitialize()
        {
            mAgent = Framework.Provider.GetServices<IDesktopAgent>().First(m => m.Id == Context.FullTestName);            
        }
    }
}
