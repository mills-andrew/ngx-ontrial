using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnTrial.Utilities;

namespace OnTrial.Api
{
    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public partial class ApiClient
    {
        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>An instance of the HttpClient</value>
        protected HttpClient mClient { get; set; }

        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        /// <value>An instance of the Configuration.</value>
        public Configuration Configuration { get; set; }

        public string Scheme { get; private set; }
        public string HostName { get; private set; }
        public string Port { get; private set; }

        private Uri finalUri = null;
        public Uri ToUri
        {
            get => finalUri ??= new Uri(string.Format("{0}://{1}:{2}/", this.Scheme, this.HostName, this.Port));
            set { finalUri = value; }
        }

        /// <summary>
        /// Gets the <see cref="HttpClient"/> Timeout.
        /// </summary>
        public int Timeout
        {
            get
            {
                return Convert.ToInt32(mClient.Timeout.TotalMilliseconds);
            }
            set
            {
                mClient.Timeout = TimeSpan.FromMilliseconds(value);
            }
        }

        #region Constructor(s)

        public ApiClient(string pUrl, Configuration pConfig = null) : this(new Uri(pUrl), pConfig) { }
        public ApiClient(Uri pUri, Configuration pConfig = null) : this(pUri.Scheme, pUri.Host, pUri.Port.ToString(), pConfig) { }
        private ApiClient(string pScheme = null, string pHostName = null, string pPort = null, Configuration pConfig = null)
        {
            Scheme = pScheme != null ? pScheme : "https";
            HostName = pHostName != null ? pHostName : throw new ArgumentNullException("Host Name cannot be null");
            Port = pPort != null ? pPort : null;
            Configuration = pConfig != null ? pConfig : new Configuration();

            HttpClientHandler httpClientHandler = new HttpClientHandler();

            if (!string.IsNullOrEmpty(this.ToUri.UserInfo) && this.ToUri.UserInfo.Contains(":"))
            {
                httpClientHandler.Credentials = new NetworkCredential(Configuration.Username, Configuration.Password);
                httpClientHandler.PreAuthenticate = true;
            }

            mClient = new HttpClient(httpClientHandler);
            mClient.DefaultRequestHeaders.UserAgent.ParseAdd(Configuration.UserAgent);
            mClient.Timeout = TimeSpan.FromMilliseconds(Configuration.Timeout);
        }

        #endregion

        #region Private Method(s)

        /// <summary>
        /// Creates and sets up a RestRequest prior to a call.
        /// </summary>
        /// <returns>WebRequest</returns>
        private HttpRequestMessage PrepareRequest(string pMethod, string pPath, object pBody, Dictionary<string, string> pHeaderParams, string pConentType)
        {
            Uri.TryCreate(ToUri, pPath, out Uri finalUri);
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(pMethod), finalUri);
            
            if (pHeaderParams != null)
            {
                foreach (var param in pHeaderParams)
                    request.Headers.Add(param.Key, param.Value);
            }

            if (pBody != null)
            {
                if (pBody.GetType() == typeof(string))
                {
                    request.Headers.Add("Accept", "application/json");
                    request.Content = new StringContent(Convert.ToString(pBody), System.Text.Encoding.UTF8, "application/json");
                }
                else if (pBody.GetType() == typeof(byte[]))
                    throw new NotImplementedException();
            }

            return request;
        }

        private HttpResponseMessage SendRequestAsync(string pMethod, string pPath) => this.SendRequestAsync(pMethod, pPath, null, null, null);
        private HttpResponseMessage SendRequestAsync(string pMethod, string pPath, object pBody) => this.SendRequestAsync(pMethod, pPath, pBody, null, null);
        private HttpResponseMessage SendRequestAsync(string pMethod, string pPath, object pBody, string pContentType) => this.SendRequestAsync(pMethod, pPath, pBody, null, pContentType);
        private HttpResponseMessage SendRequestAsync(string pMethod, string pPath, object pBody, Dictionary<string, string> pHeaderParams) => this.SendRequestAsync(pMethod, pPath, pBody, pHeaderParams, null);

        private HttpResponseMessage SendRequestAsync(string pMethod, string pPath, object pBody, Dictionary<string, string> pHeaderParams, string pContentType)
        {
            var request = this.PrepareRequest(pMethod, pPath, pBody, pHeaderParams, pContentType);

            // Use TaskFactory to avoid deadlock in multithreaded implementations.
            var response = new TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default)
                .StartNew(() => this.mClient.SendAsync(request))
                .Unwrap()
                .GetAwaiter()
                .GetResult();
            return response;
        }


        #endregion

        #region Public Method(s)

        public HttpResponseMessage SendRequestAsync(ApiMethod pMethod, string pPath) => SendRequestAsync(pMethod.ToString(), pPath);
        public HttpResponseMessage SendRequestAsync(ApiMethod pMethod, string pPath, object pBody) => SendRequestAsync(pMethod.ToString(), pPath, pBody);
        public HttpResponseMessage SendRequestAsync(ApiMethod pMethod, string pPath, object pBody, string pContentType) => SendRequestAsync(pMethod.ToString(), pPath, pBody, pContentType);
        public HttpResponseMessage SendRequestAsync(ApiMethod pMethod, string pPath, object pBody, Dictionary<string, string> pHeaderParams) => SendRequestAsync(pMethod.ToString(), pPath, pBody, pHeaderParams);
        public HttpResponseMessage SendRequestAsync(ApiMethod pMethod, string pPath, object pBody, Dictionary<string, string> pHeaderParams, string pContentType) => SendRequestAsync(pMethod.ToString(), pPath, pBody, pHeaderParams, pContentType);

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public async Task<object> Deserialize(HttpResponseMessage response, Type type)
        {
            HttpResponseHeaders headers = response.Headers;

            if (type == typeof(byte[]))
                return await response.Content.ReadAsByteArrayAsync();

            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    var filePath = string.IsNullOrEmpty(Configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : Configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + FileUtils.SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, await response.Content.ReadAsByteArrayAsync());
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(await response.Content.ReadAsByteArrayAsync());
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
                return DateTime.Parse(response.Content.ReadAsStringAsync().Result, null, DateTimeStyles.RoundtripKind);

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
                return Convert.ChangeType(response.Content, type);

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), type, new JsonSerializerSettings
                {
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); // 500
            }
        }

        #endregion

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string)
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public static string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
                return null;

            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return String.Join(",", accepts);
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="pContentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public static string SelectHeaderContentType(string[] pContentTypes)
        {
            if (pContentTypes.Length == 0)
                return null;

            if (pContentTypes.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return pContentTypes[0]; // use the first content type specified in 'consumes'
        }
    }
}
