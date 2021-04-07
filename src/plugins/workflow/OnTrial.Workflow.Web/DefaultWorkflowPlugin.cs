using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;
using OnTrial.Logger;
using OnTrial.Web.Default.Chrome;
using OnTrial.Web;
using System.Linq;
using System.Reflection;
using OnTrial.Web.Default.Edge;
using OnTrial.Web.Default.IE;

namespace OnTrial.Workflow.Web
{
    /// <summary>
    /// Author: Andrew Mills
    /// </summary>
    public class DefaultWorkflowPlugin : WorkflowPlugin
    {
        public DefaultWorkflowPlugin() { }

        #region Overriden Method(s)

        #region TestSuite Subscription(s)

        protected override void PreTestSuiteInit(object sender, WorkflowEventArgs e)
        { 
            Log.Information("Pre-Test Suite Initializer"); 
        }

        protected override void PostTestSuiteInit(object sender, WorkflowEventArgs e)
        { 
            Log.Information("Post-Test Suite Initializer"); 
        }

        protected override void PreTestSuiteCleanup(object sender, WorkflowEventArgs e)
        { 
            Log.Information("Pre-Test Suite Cleanup"); 
        }

        protected override void PostTestSuiteCleanup(object sender, WorkflowEventArgs e)
        { 
            Log.Information("Post-Test Suite Cleanup"); 
        }

        #endregion

        #region TestCase Subscription(s)

        protected override void PreTestCaseInit(object sender, WorkflowEventArgs e) 
        {
            Log.Information("Pre-Test Case Initializer");

            IWebAgent agent = null;

            //Identify which agent we need to use
            //TODO: Remove ugly duplicated code: YOU CAN DO BETTER!
            var attributes = e.TestMethodMemberInfo.GetCustomAttributes();
            if (attributes.Any(x => x.GetType().Equals(typeof(BrowserAttribute)) || x.GetType().IsSubclassOf(typeof(BrowserAttribute))))
            {
                var browserAttribute = (BrowserAttribute)attributes.First(m => m.GetType().Equals(typeof(BrowserAttribute)));

                switch (browserAttribute.Browser)
                {
                    case BrowserType.Chrome:
                        agent = new ChromeDriver(e.TestFullName);
                        break;
                    case BrowserType.Edge:
                        agent = new EdgeDriver(e.TestFullName);
                        break;
                    case BrowserType.IE:
                        agent = new IEDriver(e.TestFullName);
                        break;
                    case BrowserType.Firefox:
                        break;
                    default:
                        break;
                }
            }
            
            if (agent == null)
            {
                attributes = e.TestClassType.GetCustomAttributes();
                if (attributes.Any(x => x.GetType().Equals(typeof(BrowserAttribute)) || x.GetType().IsSubclassOf(typeof(BrowserAttribute))))
                {
                    var browserAttribute = (BrowserAttribute)attributes.First(m => m.GetType().Equals(typeof(BrowserAttribute)));

                    switch (browserAttribute.Browser)
                    {
                        case BrowserType.Chrome:
                            agent = new ChromeDriver(e.TestFullName);
                            break;
                        case BrowserType.Edge:
                            agent = new EdgeDriver(e.TestFullName);
                            break;
                        case BrowserType.IE:
                            agent = new IEDriver(e.TestFullName);
                            break;
                        case BrowserType.Firefox:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var browserType = e.Properties["browser.default"]?.ToString().ToEnum<BrowserType>() ?? BrowserType.Chrome;
                    switch (browserType)
                    {
                        case BrowserType.Chrome:
                            agent = new ChromeDriver(e.TestFullName);
                            break;
                        case BrowserType.Edge:
                            agent = new EdgeDriver(e.TestFullName);
                            break;
                        case BrowserType.IE:
                            agent = new IEDriver(e.TestFullName);
                            break;
                        case BrowserType.Firefox:
                            break;
                        default:
                            break;
                    }
                }
            }

            agent.Service.Start();
            agent.Session.NewSession();
            Framework.Construct().Services.AddScoped<IWebAgent>(a => agent);
            Framework.Construct().Build();
        }

        protected override void PostTestCaseInit(object sender, WorkflowEventArgs e)
        {
            Log.Information("Post-Test Case Initializer");
        }

        protected override void PreTestCaseCleanup(object sender, WorkflowEventArgs e) 
        {
            Log.Information("Pre-Test Case Cleanup");
            IWebAgent agent = Framework.Provider.GetServices<IWebAgent>().First(m => m.Id == e.TestFullName);
            agent.Session.DeleteSession();
            agent.Service.Stop();
            //Framework.Construct().Services.Remove<WebElement>();
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