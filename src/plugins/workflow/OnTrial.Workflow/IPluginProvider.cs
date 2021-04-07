using System;

namespace OnTrial.Workflow
{
    /// <summary>
    /// Author: Andrew Mills
    /// </summary>
    public interface IPluginProvider<TArgs>
    {
        #region Framework Event(s)

        event EventHandler<TArgs> PreFrameworkInitEvent;
        event EventHandler<TArgs> PostFrameworkInitEvent;

        event EventHandler<TArgs> PreFrameworkCleanupEvent;
        event EventHandler<TArgs> PostFrameworkCleanupEvent;

        #endregion

        #region TestSuite Event(s)

        event EventHandler<TArgs> PreTestSuiteInitEvent;
        event EventHandler<TArgs> PostTestSuiteInitEvent;

        event EventHandler<TArgs> PreTestSuiteCleanupEvent;
        event EventHandler<TArgs> PostTestSuiteCleanupEvent;

        #endregion

        #region TestCase Event(s)

        event EventHandler<TArgs> PreTestCaseInitEvent;
        event EventHandler<TArgs> PostTestCaseInitEvent;

        event EventHandler<TArgs> PreTestCaseCleanupEvent;
        event EventHandler<TArgs> PostTestCaseCleanupEvent;

        #endregion

        #region Status Event(s)

        event EventHandler<TArgs> PreTestCasePassedEvent;
        event EventHandler<TArgs> PostTestCasePassedEvent;

        event EventHandler<TArgs> PreTestCaseInconclusiveEvent;
        event EventHandler<TArgs> PostTestCaseInconclusiveEvent;

        event EventHandler<TArgs> PreTestCaseFailedEvent;
        event EventHandler<TArgs> PostTestCaseFailedEvent;

        #endregion
    }
}
