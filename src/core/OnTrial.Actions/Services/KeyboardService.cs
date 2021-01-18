using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnTrial.Actions
{
    public class KeyboardService : KeyInputSource<ActionsService>
    {
        #region Protected Variables

        protected ActionsService mBuilder;

        #endregion

        #region Constructor(s)

        public KeyboardService(ActionsService pBuilder)
        {
            this.mBuilder = pBuilder;
            base.Actions = new List<Dictionary<string, object>>();
        }

        #endregion

        #region Typing Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKeys"></param>
        /// <returns></returns>
        public ActionsService SendKeys(string pKeys)
        {
            foreach (char key in pKeys)
            {
                this.KeyDown(key);
                this.KeyUp(key);
            }
            return mBuilder;
        }

        public ActionsService SendKeys(char pModifier, string pKeys)
        {
            this.KeyDown(pModifier);

            foreach (char key in pKeys)
            {
                this.KeyDown(key);
                this.KeyUp(key);
            }

            this.KeyUp(pModifier);
            return mBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pElement"></param>
        /// <param name="pKeys"></param>
        /// <returns></returns>
        //public ActionsService SendKeys(WebElement pElement, string pKeys)
        //{
        //    mBuilder.Mouse.Click(pElement);
        //    SendKeys(pKeys);
        //    return mBuilder;
        //}

        #endregion

        #region Base Method(s)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public override ActionsService KeyDown(char pKey)
        {
            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "keyDown" },
                { "value", pKey }
            });

            return this.mBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public override ActionsService KeyUp(char pKey)
        {
            mBuilder.AddAction(this.Type, new Dictionary<string, object>()
            {
                { "type", "keyUp" },
                { "value", pKey }
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
                { "type", "key" },
                { "id", "default keyboard" },
                { "actions", Actions }
            };
        }

        #endregion
    }
}