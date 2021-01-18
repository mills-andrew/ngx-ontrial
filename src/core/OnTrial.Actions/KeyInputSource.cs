using System.Collections.Generic;

namespace OnTrial.Actions
{
    /// <summary>
    /// A key input source is an input source that is associated with a keyboard-type device. A key input source supports the same pause action as a null input source plus the following actions
    /// keyDown:    Used to indicate that a particular key should be held down.
    /// keyUp:      Used to indicate that a depressed key should be released.
    /// </summary>
    /// <typeparam name="TActions"></typeparam>
    public abstract class KeyInputSource<TActions> : IDevice
    {
        #region Public Properties

        public string Name { get; set; }
        public string Type => InputSourceState.Key;

        public List<Dictionary<string, object>> Actions { get; set; }

        #endregion

        #region Base Method(s)

        /// <summary>
        /// Used to indicate that a particular key should be held down.
        /// </summary>
        public abstract TActions KeyDown(char pKey);

        /// <summary>
        /// Used to indicate that a depressed key should be released.
        /// </summary>
        public abstract TActions KeyUp(char pKey);

        #endregion
    }
}
