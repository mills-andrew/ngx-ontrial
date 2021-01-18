using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Actions
{
    public class MouseService : PointerInputSource<ActionsService>
    {
        #region Protected Variables

        protected ActionsService mBuilder;

        #endregion

        public ActionsService Builder { get => mBuilder; }

        #region Constructor(s)

        public MouseService(ActionsService pActions)
        {
            this.mBuilder = pActions;
            base.Actions = new List<Dictionary<string, object>>();
        }

        #endregion

        #region Clicking Method(s)

        public ActionsService Click()
        {
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);
            
            return this.mBuilder;
        }

        public ActionsService Click(Dictionary<string, object> pTarget)
        {
            this.PointerMove(pTarget, new Point(0, 0));
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);

            return this.mBuilder;
        }

        public ActionsService MiddleClick()
        {
            this.PointerDown(PointerButtonType.Middle);
            this.PointerUp(PointerButtonType.Middle);

            return this.mBuilder;
        }

        public ActionsService MiddleClick(Dictionary<string, object> pTarget)
        {
            this.PointerMove(pTarget, new Point(0, 0));
            this.PointerDown(PointerButtonType.Middle);
            this.PointerUp(PointerButtonType.Middle);

            return this.mBuilder;
        }

        public ActionsService RightClick()
        {
            this.PointerDown(PointerButtonType.Right);
            this.PointerUp(PointerButtonType.Right);

            return this.mBuilder;
        }

        public ActionsService RightClick(Dictionary<string, object> pTarget)
        {
            this.PointerMove(pTarget, new Point(0, 0));
            this.PointerDown(PointerButtonType.Right);
            this.PointerUp(PointerButtonType.Right);

            return this.mBuilder;
        }

        public ActionsService DoubleClick()
        {
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);

            return this.mBuilder;
        }

        public ActionsService DoubleClick(Dictionary<string, object> pTarget)
        {
            this.PointerMove(pTarget, new Point(0, 0));
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);
            this.PointerDown(PointerButtonType.Left);
            this.PointerUp(PointerButtonType.Left);

            return this.mBuilder;
        }

        #endregion

        #region Drag and Drop Method(s)

        public ActionsService DragDrop(Dictionary<string, object> pSource, Dictionary<string, object> pTarget)
        {
            this.DragDrop(pSource, pTarget, new Point(0, 0));

            return this.mBuilder;
        }

        public ActionsService DragDrop(Dictionary<string, object> pSource, Dictionary<string, object> pTarget, Point pOffset)
        {
            this.PointerMove(pSource, new Point(0, 0));
            this.PointerDown(PointerButtonType.Left);
            this.PointerMove(pTarget, pOffset, TimeSpan.Zero);
            this.PointerUp(PointerButtonType.Left);

            return this.mBuilder;
        }

        #endregion

        #region Base Method(s)

        /// <summary>
        /// Used to indicate that a pointer should be depressed in some way e.g. by holding a button down (for a mouse) or by coming into contact with the active surface (for a touch or pen device).
        /// </summary>
        /// <param name="pButton"></param>
        /// <returns></returns>
        public override ActionsService PointerDown(PointerButtonType pButton)
        {
            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "pointerDown" },
                { "button", Convert.ToInt32(pButton) }
            });

            return this.mBuilder;
        }

        /// <summary>
        /// Used to indicate that a pointer should be released in some way e.g. by releasing a mouse
        /// button or moving a pen or touch device away from the active surface.
        /// </summary>
        /// <param name="pButton"></param>
        /// <returns></returns>
        public override ActionsService PointerUp(PointerButtonType pButton)
        {
            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "pointerUp" },
                { "button", Convert.ToInt32(pButton) }
            });

            return this.mBuilder;
        }

        /// <summary>
        /// Used to indicate a location on the screen that a pointer should move to, either in its active (pressed) or inactive state.
        /// </summary>
        /// <param name="pTarget"></param>
        /// <param name="pOffset"></param>
        /// <param name="pDuration"></param>
        /// <returns></returns>
        public override ActionsService PointerMove(Dictionary<string, object> pTarget, Point pOffset, TimeSpan? pDuration = null)
        {
            object origin;
            if (pTarget == null)
                origin = "pointer";
            else
                origin = pTarget;

            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "pointerMove" },
                { "duration", 250 },
                { "origin", origin },
                { "x", pOffset.X },
                { "y", pOffset.Y }
            });

            return this.mBuilder;
        }

        /// <summary>
        /// Used to cancel a pointer action.
        /// </summary>
        /// <returns></returns>
        public override ActionsService PointerCancel()
        {
            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "pointerCancel" }
            });

            return this.mBuilder;
        }

        #endregion

        #region Conversion Method(s)

        /// <summary>
        /// Will serialize the dictionary method to a readable string formate
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.ToDictionary(), Formatting.Indented);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                { "type", "pointer" },
                { "id", "default mouse" },
                { "parameters", new Dictionary<string, object>() { { "pointerType", "mouse" } } },
                { "actions", Actions }
            };
        }

        #endregion
    }
}
