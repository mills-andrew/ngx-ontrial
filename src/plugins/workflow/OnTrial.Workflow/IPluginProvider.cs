using System;

namespace OnTrial.Workflow
{
    public interface IPluginProvider<TArgs>
    {
        #region TestCase Event(s)

        event EventHandler<TArgs> PreTestCaseInitEvent;
        event EventHandler<TArgs> PostTestCaseInitEvent;

        event EventHandler<TArgs> PreTestCaseCleanupEvent;
        event EventHandler<TArgs> PostTestCaseCleanupEvent;

        #endregion

        #region Status Event(s)

        event EventHandler<TArgs> PreTestPassedEvent;
        event EventHandler<TArgs> PostTestPassedEvent;

        event EventHandler<TArgs> PreTestInconclusiveEvent;
        event EventHandler<TArgs> PostTestInconclusiveEvent;

        event EventHandler<TArgs> PreTestFailedEvent;
        event EventHandler<TArgs> PostTestFailedEvent;

        #endregion
    }
}
