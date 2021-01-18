using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OnTrial.Utilities;

namespace OnTrial.Api
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the timeout value for our client requests (miliseconds)
        /// </summary>
        public double Timeout { get; private set; }

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public string TempFolderPath
        {
            get
            {
                // default to Path.GetTempPath() if _tempFolderPath is not set
                if (string.IsNullOrEmpty(_tempFolderPath))
                    _tempFolderPath = Path.GetTempPath();
                return _tempFolderPath;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value + Path.DirectorySeparatorChar;
            }
        }

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public string DateTimeFormat
        {
            get => _dateTimeFormat;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        #endregion

        #region Public Variables

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "1.0.0";

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public Dictionary<string, string> ApiKey = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public Dictionary<string, string> ApiKeyPrefix = new Dictionary<string, string>();

        #endregion

        #region Private Variables

        private const string ISO8601_DATETIME_FORMAT = "o";

        private string _tempFolderPath;
        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the Configuration class with different settings
        /// </summary>
        /// <param name="pUsername">Username</param>
        /// <param name="pPassword">Password</param>
        /// <param name="pAccessToken">accessToken</param>
        /// <param name="pApiKey">Dictionary of API key</param>
        /// <param name="pApiKeyPrefix">Dictionary of API key prefix</param>
        /// <param name="pTempFolderPath">Temp folder path</param>
        /// <param name="pDateTimeFormate">DateTime format string</param>
        /// <param name="pTimeout">HTTP connection timeout (in milliseconds)</param>
        public Configuration(string pUsername = null, string pPassword = null, string pAccessToken = null,
                             Dictionary<string, string> pApiKey = null, Dictionary<string, string> pApiKeyPrefix = null,
                             string pTempFolderPath = null, string pDateTimeFormate = null, int pTimeout = 100000)
        {
            UserAgent = string.Format("OnTrial/{0} (.net {1})", ResourceUtils.AssemblyVersion, ResourceUtils.PlatformFamily);

            Username = pUsername;
            Password = pPassword;
            AccessToken = pAccessToken;

            if (pApiKey != null)
                ApiKey = pApiKey;
            if (pApiKeyPrefix != null)
                ApiKeyPrefix = pApiKeyPrefix;

            TempFolderPath = pTempFolderPath;
            DateTimeFormat = pDateTimeFormate;
            this.Timeout = pTimeout;
        }

        #endregion

        #region Public Method(s)

        /// <summary>
        /// Add Api Key Header.
        /// </summary>
        /// <param name="pKey">Api Key name.</param>
        /// <param name="pValue">Api Key value.</param>
        /// <returns></returns>
        public void AddApiKey(string pKey, string pValue)
        {
            ApiKey[pKey] = pValue;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="pKey">Api Key name.</param>
        /// <param name="pValue">Api Key value.</param>
        public void AddApiKeyPrefix(string pKey, string pValue)
        {
            ApiKeyPrefix[pKey] = pValue;
        }

        /// <summary>
        /// Get the API key with prefix.
        /// </summary>
        /// <param name="pApiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string pApiKeyIdentifier)
        {
            ApiKey.TryGetValue(pApiKeyIdentifier, out string apiKeyValue);
            return ApiKeyPrefix.TryGetValue(pApiKeyIdentifier, out string apiKeyPrefix) ? $"{apiKeyPrefix} {apiKeyValue}" : apiKeyValue;
        }

        #endregion
    }
}
