namespace OnTrial.Web
{
    /// <summary>
    /// Enumerator for identifing which browser a test will run on.
    /// </summary>
    public enum BrowserType
    {
        /// <summary>
        /// Any browser will be controlled by the runsettings (Defaults to Edge)
        /// </summary>
        Any,

        /// <summary>
        /// Specifies Chrome will run this Test
        /// </summary>
        Chrome,

        /// <summary>
        /// Specifies IE will run this Test
        /// </summary>
        IE,
        
        /// <summary>
        /// Specifies Edge will run this Test
        /// </summary>
        Edge,

        /// <summary>
        /// Specifies Firefox will run this Test
        /// </summary>
        Firefox
    }
}
