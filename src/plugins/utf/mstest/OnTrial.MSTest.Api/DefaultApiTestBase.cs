using OnTrial.IOC;
using OnTrial.Logger;

namespace OnTrial.MSTest.Api
{
    [TestSuite]
    public class DefaultApiTestBase : MSTestBase
    {
        public override void FrameworkInitialize()
        {
            Framework.Construct()
                .AddDefaultConfiguration()
                .AddConsoleLogger()
                .AddMSTestAssert()
                .Build();

            base.FrameworkInitialize();
        }
    }
}
