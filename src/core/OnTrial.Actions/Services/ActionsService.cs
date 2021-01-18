using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OnTrial.Actions
{
    public class ActionsService
    {
        #region Public Variables

        public Func<IDictionary<string, object>> ExecutionCall;
        public MouseService Mouse { get; set; }
        public KeyboardService Keyboard { get; set; }
        public List<Dictionary<string, object>> Sequence { get; set; }

        #endregion

        #region Protected Variables

        protected Dictionary<string, object> mPause;
        
        #endregion

        #region Constructor(s)

        public ActionsService()
        {
            this.Keyboard = new KeyboardService(this);
            this.Mouse = new MouseService(this);
            this.Sequence = new List<Dictionary<string, object>>();

            this.mPause = new Dictionary<string, object>()
            {
                { "type", "pause" },
                { "duration", 0 }
            };
        }

        #endregion

        #region Internal Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSource"></param>
        /// <param name="pAction"></param>
        internal void AddAction(string pSource, Dictionary<string, object> pAction)
        {
            if (pSource == Mouse.Type)
            {
                this.Mouse.Actions.Add(pAction);
                this.Keyboard.Actions.Add(mPause);
            }
            else if (pSource == Keyboard.Type)
            {
                this.Mouse.Actions.Add(mPause);
                this.Keyboard.Actions.Add(pAction);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSource"></param>
        /// <param name="pAction"></param>
        internal void RemoveAction(string pSource, Dictionary<string, object> pAction)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pActions"></param>
        /// <param name="pAgent"></param>
        public void Perform()
        {
            //Execute the actions
            this.ExecutionCall();

            //Clear our builder and actions so we can use again
            this.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            //Clear our actions after we use them
            Sequence.Clear();
            Mouse.Actions.Clear();
            Keyboard.Actions.Clear();
        }

        #endregion

        #region Conversion Method(s)

        /// <summary>
        /// 
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
                { "actions", new List<Dictionary<string, object>>()
                    {
                        { Mouse.ToDictionary() },
                        { Keyboard.ToDictionary() }
                    }
                }
            };
        }

        #endregion
    }
}
