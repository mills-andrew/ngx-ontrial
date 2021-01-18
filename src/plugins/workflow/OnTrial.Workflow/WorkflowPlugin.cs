namespace OnTrial.Workflow
{
    public class WorkflowPlugin
    {
        /// <summary>
        /// Subscribe all associated events to this plugin
        /// </summary>
        /// <param name="pProvider"></param>
        public void Subscribe(IPluginProvider<WorkflowEventArgs> pProvider)
        {
            #region TestCase Subscription(s)

            pProvider.PreTestCaseInitEvent += PreTestCaseInit;
            pProvider.PostTestCaseInitEvent += PostTestCaseInit;

            pProvider.PreTestCaseCleanupEvent += PreTestCaseCleanup;
            pProvider.PostTestCaseCleanupEvent += PostTestCaseCleanup;
            
            #endregion

            #region TestEvent Subscription(s)

            pProvider.PreTestPassedEvent += PreTestPassedEvent;
            pProvider.PostTestPassedEvent += PostTestPassedEvent;

            pProvider.PreTestInconclusiveEvent += PreTestInconclusiveEvent;
            pProvider.PostTestInconclusiveEvent += PostTestInconclusiveEvent;

            pProvider.PreTestFailedEvent += PreTestFailedEvent;
            pProvider.PostTestFailedEvent += PostTestFailedEvent;
         
            #endregion
        }

        /// <summary>
        /// Unsubscribe all associated events to this plugin
        /// </summary>
        /// <param name="pProvider"></param>
        public void Unsubscribe(IPluginProvider<WorkflowEventArgs> pProvider)
        {
            #region TestCase Subscription(s)

            pProvider.PreTestCaseInitEvent -= PreTestCaseInit;
            pProvider.PostTestCaseInitEvent -= PostTestCaseInit;

            pProvider.PreTestCaseCleanupEvent -= PreTestCaseCleanup;
            pProvider.PostTestCaseCleanupEvent -= PostTestCaseCleanup;

            #endregion

            #region TestEvent Subscription(s)

            pProvider.PreTestPassedEvent -= PreTestPassedEvent;
            pProvider.PostTestPassedEvent -= PostTestPassedEvent;

            pProvider.PreTestInconclusiveEvent -= PreTestInconclusiveEvent;
            pProvider.PostTestInconclusiveEvent -= PostTestInconclusiveEvent;

            pProvider.PreTestFailedEvent -= PreTestFailedEvent;
            pProvider.PostTestFailedEvent -= PostTestFailedEvent;

            #endregion
        }
        
        #region TestCase Subscription(s)

        protected virtual void PreTestCaseCleanup(object sender, WorkflowEventArgs e) { }
        protected virtual void PostTestCaseCleanup(object sender, WorkflowEventArgs e) { }

        protected virtual void PreTestCaseInit(object sender, WorkflowEventArgs e) { }
        protected virtual void PostTestCaseInit(object sender, WorkflowEventArgs e) { }

        #endregion

        #region TestEvent Subscription(s)

        protected virtual void PreTestPassedEvent(object sender, WorkflowEventArgs e) { }
        protected virtual void PostTestPassedEvent(object sender, WorkflowEventArgs e) { }
        protected virtual void PreTestInconclusiveEvent(object sender, WorkflowEventArgs e) { }
        protected virtual void PostTestInconclusiveEvent(object sender, WorkflowEventArgs e) { }
        protected virtual void PreTestFailedEvent(object sender, WorkflowEventArgs e) { }
        protected virtual void PostTestFailedEvent(object sender, WorkflowEventArgs e) { }

        #endregion
    }
}
