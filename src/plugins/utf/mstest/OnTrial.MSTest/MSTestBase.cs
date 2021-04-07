using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnTrial.IOC;
using OnTrial.Logger;
using OnTrial.Workflow;
using System;

namespace OnTrial.MSTest
{
    [TestClass]
    public class MSTestBase
    {
        public TestContext TestContext { get; set; }
        protected MSTestContext Context;
        private WorkflowProvider _curWorkflowProvider = new WorkflowProvider();

        private static bool hasInitFramework, hasInitSuite, hasCleanupFramework, hasCleanupSuite = false;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext pContext)
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        [ClassInitialize]
        public static void TestSuiteInit(TestContext pContext)
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            if (Context == null)
                Context = new MSTestContext(TestContext);

            try
            {
                #region Framework Initalize
               
                if (hasInitFramework == false)
                {
                    //Build our framework before subscribing our services
                    Framework.Construct().Build();

                    _curWorkflowProvider.PreFrameworkInit();
                    FrameworkInitialize();
                    _curWorkflowProvider.PostFrameworkInit();
                }

                #endregion

                #region Suite Initialize

                if (hasInitSuite == false)
                {
                    _curWorkflowProvider.PreTestSuiteInit();
                    TestSuiteInitialize();
                    _curWorkflowProvider.PostTestSuiteInit();
                }

                #endregion

                #region Test Initialize

                var methodType = GetType().Assembly.GetType(Context.ClassName).GetMethod(Context.MethodName);
                var classType = GetType();

                //Subscribe all our related providers to our plugin
                Framework.Service<WorkflowPlugin>()?.Subscribe(_curWorkflowProvider);

                //Call all associated pre test initialization methods
                _curWorkflowProvider.PreTestCaseInit(Context.Properties, Context.MethodName, methodType, classType);

                //Call associated test initializer
                TestInitialize();

                //Call all associated post test initialization methods
                _curWorkflowProvider.PostTestCaseInit(Context.Properties, Context.MethodName, methodType, classType);

                #endregion
            }
            catch (Exception)
            {
                //Let anyone who cares know that the test has failed
                _curWorkflowProvider.PreTestFailed(TestContext.TestName);
                _curWorkflowProvider.PostTestFailed(TestContext.TestName);
                throw;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                #region Test Cleanup

                var methodType = GetType().Assembly.GetType(Context.ClassName).GetMethod(Context.MethodName);
                var classType = GetType();

                //Let subscribers know about the preTest clean up is being called
                _curWorkflowProvider.PreTestCaseCleanup(Context.Properties, Context.MethodName, methodType, classType);

                //Call the associated test clean up method. 
                TestCleanup();

                //Let subscribers know that the post clean up method is being called
                _curWorkflowProvider.PostTestCaseCleanup(Context.Properties, Context.MethodName, methodType, classType);

                #endregion

                #region Suite Cleanup

                if (hasCleanupSuite == false)
                {
                    _curWorkflowProvider.PreTestSuiteCleanup();
                    TestSuiteCleanup();
                    _curWorkflowProvider.PostTestSuiteCleanup();
                }

                #endregion

                #region Framework Cleanup

                if (hasCleanupFramework == false)
                {
                    _curWorkflowProvider.PreFrameworkCleanup();
                    FrameworkCleanup();
                    _curWorkflowProvider.PostFrameworkCleanup();
                }

                #endregion
            }
            catch (Exception)
            {
                //Let anyone who cares know that the test has failed
                _curWorkflowProvider.PreTestFailed(TestContext.TestName);
                _curWorkflowProvider.PostTestFailed(TestContext.TestName);
                throw;
            }
        }

        #region Virtual Method(s)

        public virtual void FrameworkInitialize() 
        {
            Log.Information("Framework Initialize");
            hasInitFramework = true;
        }

        public virtual void FrameworkCleanup() 
        { 
            Log.Information("Framework Cleanup");
            hasCleanupFramework = true;
        }

        public virtual void TestSuiteInitialize() 
        { 
            Log.Information("Suite Initialize");
            hasInitSuite = true;
        }

        public virtual void TestSuiteCleanup() 
        { 
            Log.Information("Suite Cleanup");
            hasCleanupSuite = true;
        }

        public virtual void TestCaseInitialize() 
        {
            Log.Information("Test Initialize");
        }

        public virtual void TestCaseCleanup() 
        { 
            Log.Information("Test Cleanup");
        }

        #endregion
    }
}