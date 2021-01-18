using System;
using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Actions
{
    /// <summary>
    /// A pointer input source is an input source that is associated with a pointer-type input device. 
    /// Such an input source has an associated pointer type specifying exactly which kind of pointing device it is associated with. 
    /// A pointer input source supports the same pause action as a null input source plus the following actions:
    /// pointerDown:    Used to indicate that a pointer should be depressed in some way e.g.by holding a button down(for a mouse) or by coming into contact with the active surface(for a touch or pen device).
    /// pointerUp:      Used to indicate that a pointer should be released in some way e.g.by releasing a mouse button or moving a pen or touch device away from the active surface.
    /// pointerMove:    Used to indicate a location on the screen that a pointer should move to, either in its active(pressed) or inactive state.
    /// pointerCancel:  Used to cancel a pointer action.
    /// </summary>
    /// <typeparam name="TActions"></typeparam>
    public abstract class PointerInputSource<TAgent> : IDevice
    {
        #region Public Properties

        public string Name { get; set; }
        public string Type => InputSourceState.Pointer;

        public List<Dictionary<string, object>> Actions { get; set; }

        #endregion

        #region Base Method(s)

        /// <summary>
        /// Used to indicate that a pointer should be depressed in some way e.g.by holding a button down(for a mouse)
        /// or by coming into contact with the active surface(for a touch or pen device). 
        /// </summary>
        public abstract TAgent PointerDown(PointerButtonType pButton);

        /// <summary>
        /// Used to indicate that a pointer should be released in some way e.g.by releasing a mouse button or moving a pen or touch device 
        /// away from the active surface.
        /// </summary>
        public abstract TAgent PointerUp(PointerButtonType pButton);

        /// <summary>
        /// Used to indicate a location on the screen that a pointer should move to, either in its active(pressed) or inactive state.
        /// </summary>
        public abstract TAgent PointerMove(Dictionary<string, object> pTarget, Point pOffset, TimeSpan? pDuration = null);

        /// <summary>
        /// Used to cancel a pointer action. 
        /// </summary>
        public abstract TAgent PointerCancel();

        #endregion
    }
}
