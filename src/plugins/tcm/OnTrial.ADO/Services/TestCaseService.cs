using OnTrial.Api;
using OnTrial.Logger;
using System;
using System.Net.Http;

namespace OnTrial.ADO
{
    /// <summary>
    /// Controller to handle WIT scoped TestCase APIs
    /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20cases
    /// </summary>
    public class TestCaseService
    {
        #region Public Properties

        public string Route => this.client.ToUri.ToString();
        public ApiClient client;

        #endregion

        #region Constructor(s)

        public TestCaseService(string pUrl, string pOrganization, string pProject)
        {
            this.client = new ApiClient($"{pUrl}/{pOrganization}/{pProject}/");
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Delete a test case.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20cases
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int? pTestCaseId)
        {
            try
            {
                if (pTestCaseId is null)
                    throw new ArgumentNullException(nameof(pTestCaseId));

                return client.SendRequestAsync(ApiMethod.Delete, $"_apis/testplan/testcases/{pTestCaseId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }            
        }

        #endregion
    }
}