using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnTrial.IOC;
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

        [TestInitialize]
        public void Initialize()
        {
            if (Context == null)
                Context = new MSTestContext(TestContext);

            //Call associated core initialize - this is usually where we would build the framework construction
            FrameworkInitialize();

            //Build our framework before subscribing our services
            Framework.Construct().Build();

            //Subscribe all our related providers to from out plugin
            Framework.Service<WorkflowPlugin>().Subscribe(_curWorkflowProvider);

            try
            {
                var methodType = GetType().Assembly.GetType(Context.ClassName).GetMethod(Context.MethodName);
                var classType = GetType();

                //Call all associated pre test initialization methods
                _curWorkflowProvider.PreTestCaseInit(Context.Properties, Context.MethodName, methodType, classType);

                //Call associated test initializer
                TestInitialize();

                //Call all associated post test initialization methods
                _curWorkflowProvider.PostTestCaseInit(Context.Properties, Context.MethodName, methodType, classType);
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
        public void Cleanup()
        {
            if (Context == null)
                Context = new MSTestContext(TestContext);

            try
            {
                var methodType = GetType().Assembly.GetType(Context.ClassName).GetMethod(Context.MethodName);
                var classType = GetType();

                //Let subscribers know about the preTest clean up is being called
                _curWorkflowProvider.PreTestCaseCleanup(Context.Properties, Context.MethodName, methodType, classType);

                //Call the associated test clean up method. 
                TestCleanup();

                //Let subscribers know that the post clean up method is being called
                _curWorkflowProvider.PostTestCaseCleanup(Context.Properties, Context.MethodName, methodType, classType);
            }
            catch (Exception)
            {
                //Let anyone who cares know that the test has failed
                _curWorkflowProvider.PreTestFailed(TestContext.TestName);
                _curWorkflowProvider.PostTestFailed(TestContext.TestName);
                throw;
            }
        }

        public virtual void FrameworkInitialize() { }
        public virtual void FrameworkCleanup() { }
        public virtual void TestInitialize() { }
        public virtual void TestCleanup() { }
    }
}