using System;
using System.Collections;
using System.Reflection;

namespace OnTrial.Workflow
{
    /// <summary>
    /// Author: Andrew Mills
    /// </summary>
    public class WorkflowProvider : IPluginProvider<WorkflowEventArgs>
    {
        #region Public Event(s)

        #region Framework Event(s)

        public event EventHandler<WorkflowEventArgs> PreFrameworkInitEvent;
        public event EventHandler<WorkflowEventArgs> PostFrameworkInitEvent;
        public event EventHandler<WorkflowEventArgs> PreFrameworkCleanupEvent;
        public event EventHandler<WorkflowEventArgs> PostFrameworkCleanupEvent;

        #endregion

        #region TestSuite Event(s)

        public event EventHandler<WorkflowEventArgs> PreTestSuiteInitEvent;
        public event EventHandler<WorkflowEventArgs> PostTestSuiteInitEvent;
        public event EventHandler<WorkflowEventArgs> PreTestSuiteCleanupEvent;
        public event EventHandler<WorkflowEventArgs> PostTestSuiteCleanupEvent;

        #endregion

        #region TestCase Event(s)

        public event EventHandler<WorkflowEventArgs> PreTestCaseInitEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseInitEvent;
        public event EventHandler<WorkflowEventArgs> PreTestCaseCleanupEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseCleanupEvent;

        #endregion

        #region TestEvent(s)

        public event EventHandler<WorkflowEventArgs> PreTestCasePassedEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCasePassedEvent;
        public event EventHandler<WorkflowEventArgs> PreTestCaseInconclusiveEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseInconclusiveEvent;
        public event EventHandler<WorkflowEventArgs> PreTestCaseFailedEvent;
        public event EventHandler<WorkflowEventArgs> PostTestCaseFailedEvent;

        #endregion

        #endregion

        #region Public Method(s)

        #region Framework Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreFrameworkInit()
        {
            PreFrameworkInitEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostFrameworkInit()
        {
            PostFrameworkInitEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreFrameworkCleanup()
        {
            PreFrameworkCleanupEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostFrameworkCleanup()
        {
            PostFrameworkCleanupEvent?.Invoke(this, null);
        }

        #endregion

        #region TestSuite Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreTestSuiteInit()
        {
            PreTestSuiteInitEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostTestSuiteInit()
        {
            PostTestSuiteInitEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreTestSuiteCleanup()
        {
            PreTestSuiteCleanupEvent?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostTestSuiteCleanup()
        {
            PostTestSuiteCleanupEvent?.Invoke(this, null);
        }

        #endregion

        #region TestCase Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreTestCaseInit(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PreTestCaseInitEvent?.Invoke(this, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostTestCaseInit(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PostTestCaseInitEvent?.Invoke(this, args);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PreTestCaseCleanup(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PreTestCaseCleanupEvent?.Invoke(this, args);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProperties"></param>
        /// <param name="pTestName"></param>
        /// <param name="testMethodMemberInfo"></param>
        /// <param name="pTestClassType"></param>
        public void PostTestCaseCleanup(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType) 
        {
            var args = new WorkflowEventArgs(pProperties, pTestName, testMethodMemberInfo, pTestClassType);
            PostTestCaseCleanupEvent?.Invoke(this, args);
        }

        #endregion

        #region TestEvent Method(s)

        public void PreTestPassed(string pTestName) { }
        public void PostTestPassed(string pTestName) { }
        public void PreTestInconclusive(string pTestName) { }
        public void PostTestInconclusive(string pTestName) { }
        public void PreTestFailed(string pTestName) { }
        public void PostTestFailed(string pTestName) { }

        #endregion

        #endregion
    }
}
