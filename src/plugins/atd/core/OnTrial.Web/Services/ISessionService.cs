namespace OnTrial.Web
{
    public interface ISessionService
    {
        string Id { get; set; }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        void NewSession();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        void DeleteSession();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#status"/>
        /// </summary>
        /// <returns></returns>
        bool Status();
    }
}
