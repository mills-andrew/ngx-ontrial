using System.Collections.Generic;

namespace OnTrial.Api
{
    /// <summary>
    /// API Response
    /// </summary>
    public class Response<T>
    {
        /// <summary>
        /// Gets or sets the status code (HTTP status code)
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP headers
        /// </summary>
        /// <value>HTTP headers</value>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Gets or sets the data (parsed HTTP body)
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="pStatusCode">HTTP status code.</param>
        /// <param name="pHeaders">HTTP headers.</param>
        /// <param name="pData">Data (parsed HTTP body)</param>
        public Response(int pStatusCode, IDictionary<string, string> pHeaders, T pData)
        {
            this.StatusCode = pStatusCode;
            this.Headers = pHeaders;
            this.Data = pData;
        }
    }
}
