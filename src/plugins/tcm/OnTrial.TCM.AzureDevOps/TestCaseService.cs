using OnTrial.Api;
using System;
using System.Threading.Tasks;

namespace OnTrial.ADO
{
    /// <summary>
    /// Controller to handle WIT scoped TestCase APIs
    /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20cases
    /// </summary>
    public class TestCaseService
    {
        #region Public Properties

        public string Route => this.Api.ToUri.ToString();
        public ApiClient Api { get; set; }

        #endregion

        #region Constructor(s)

        public TestCaseService(Uri pUri)
        {
            this.Api = new ApiClient(pUri);
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Delete a test case.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20cases
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> Delete(string pTestCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"/_apis/test/testcases/{pTestCaseId}").Content.ReadAsByteArrayAsync();
        }

        #endregion
    }
}
