using System;

namespace OnTrial.Web
{
    public interface INavigationService
    {
        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#navigate-to"/>
        /// </summary>
        /// <param name="pUrl"></param>
        void NavigateTo(Uri pUrl);

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#navigate-to"/>
        /// </summary>
        /// <param name="pUrl"></param>
        void NavigateTo(string pUrl);

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#get-current-url"/>
        /// </summary>
        /// <returns>Url of current website</returns>
        string GetCurrentUrl();

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#back"/>
        /// </summary>
        void Back();

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#forward"/>
        /// </summary>
        void Forward();

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#refresh"/>
        /// </summary>
        void Refresh();

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#"/>
        /// </summary>
        /// <returns>Title of website</returns>
        string GetTitle();
    }
}
