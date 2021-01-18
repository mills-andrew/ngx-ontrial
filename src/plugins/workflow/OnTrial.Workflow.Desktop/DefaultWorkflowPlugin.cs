using Microsoft.Extensions.DependencyInjection;
using OnTrial.Desktop;
using OnTrial.Desktop.Default.Windows;
using OnTrial.IOC;
using OnTrial.Logger;
using System.Linq;
using System.Reflection;

namespace OnTrial.Workflow.Desktop
{
    public class DefaultWorkflowPlugin : WorkflowPlugin
    {
        public DefaultWorkflowPlugin() { }

        #region Overriden Method(s)

        #region TestSuite Subscription(s)

        protected override void PreTestCaseInit(object sender, WorkflowEventArgs e)
        {
            Log.Information("Pre-Test Case Initializer");

            IDesktopAgent agent = null;

            //Identify which agent we need to use
            var attributes = e.TestClassType.GetCustomAttributes();

            if (attributes.Any(x => x.GetType().Equals(typeof(AppAttribute)) || x.GetType().IsSubclassOf(typeof(AppAttribute))))
            {
                var appAttribute = (AppAttribute)attributes.First(m => m.GetType().Equals(typeof(AppAttribute)));

                switch (appAttribute.Platform)
                {
                    case PlatformType.Windows:
                        agent = new WindowsDriver(e.TestFullName, appAttribute.Directory);
                        break;
                    
                    default:
                        break;
                }
            }
            else
            {
                Log.Error("Missing App Attribute");
            }

            agent.Service.Start();
            agent.Session.NewSession();
            Framework.Construct().Services.AddScoped(a => agent);
            Framework.Construct().Build();
        }

        protected override void PostTestCaseInit(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Case Initializer");
        }

        protected override void PreTestCaseCleanup(object sender, WorkflowEventArgs e)
        {
            Log.Information("Pre-Test Case Cleanup");
            IDesktopAgent agent = Framework.Provider.GetServices<IDesktopAgent>().First(m => m.Id == e.TestFullName);
            agent.Session.DeleteSession();
            agent.Service.Stop();
        }

        protected override void PostTestCaseCleanup(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Case Cleanup");
        }

        #endregion

        #region TestEvent Subscription(s)

        protected override void PreTestPassedEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Pre-Test Passed");
        }

        protected override void PostTestPassedEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Passed");
        }

        protected override void PreTestInconclusiveEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Pre-Test Inconclusive");
        }

        protected override void PostTestInconclusiveEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Inconclusive");
        }

        protected override void PreTestFailedEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Pre-Test Failed");
        }

        protected override void PostTestFailedEvent(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Failed");
        }

        #endregion

        #endregion
    }
}