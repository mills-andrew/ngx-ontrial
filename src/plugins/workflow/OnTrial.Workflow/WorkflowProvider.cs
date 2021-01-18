using System;
using System.Collections;
using System.Reflection;

namespace OnTrial.Workflow
{
    public class WorkflowProvider : IPluginProvider<WorkflowEventArgs>
    {
        #region Public Event(s)

        #region TestSuite Event(s)

        public event EventHandler<WorkflowEventArgs> PreTestCaseInitEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseInitEvent;
        public event EventHandler<WorkflowEventArgs> PreTestCaseCleanupEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseCleanupEvent;

        #endregion

        #region Test Event(s)

        public event EventHandler<WorkflowEventArgs> PreTestPassedEvent;
        public event EventHandler<WorkflowEventArgs> PostTestPassedEvent;
        public event EventHandler<WorkflowEventArgs> PreTestInconclusiveEvent;
        public event EventHandler<WorkflowEventArgs> PostTestInconclusiveEvent;
        public event EventHandler<WorkflowEventArgs> PreTestFailedEvent;
        public event EventHandler<WorkflowEventArgs> PostTestFailedEvent;

        #endregion

        #endregion

        #region Public Method(s)

        #region TestCase Method(s)

        public void PreTestCaseInit(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PreTestCaseInitEvent?.Invoke(this, args);
        }

        public void PostTestCaseInit(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) { }
        
        public void PreTestCaseCleanup(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PreTestCaseCleanupEvent?.Invoke(this, args);
        }
        
        public void PostTestCaseCleanup(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) { }

        #endregion

        #region Test Event Method(s)

        public void PreTestPassed(string testName) { }
        public void PostTestPassed(string testName) { }
        public void PreTestInconclusive(string testName) { }
        public void PostTestInconclusive(string testName) { }
        public void PreTestFailed(string testName) { }
        public void PostTestFailed(string testName) { }

        #endregion

        #endregion
    }
}
