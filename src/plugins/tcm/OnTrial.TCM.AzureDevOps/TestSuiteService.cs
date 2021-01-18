using OnTrial.Api;
using System;
using System.Threading.Tasks;

namespace OnTrial.ADO
{
    /// <summary>
    /// Test suites help in organizing test cases in a test plan. A test suite can contain child test suites, 
    /// helping you build a folder structure under a test plan or it can contain test cases. Leaf test suites typically contain test cases, 
    /// where are intermediate suites represent a folder hierarchy. 
    /// Intermediate suites can on Static type, whereas leaf suites can be of static suites, requirement based suites or query based suites.
    /// </summary>
    public class TestSuiteService
    {
        #region Public Properties

        public string Route => this.Api.ToUri.ToString();
        public ApiClient Api { get; set; }

        #endregion

        #region Constructor(s)

        public TestSuiteService(Uri pUri)
        {
            this.Api = new ApiClient(pUri);
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Add test cases to suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/add
        /// </summary>
        /// <returns>Status 200, 404</returns>
        public async Task<byte[]> Add(string pPlanId, string pSuiteId, string pCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Post, $"_apis/test/Plans/{pPlanId}/suites/{pSuiteId}/testcases/{pCaseId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Get	a specific test case in a test suite with test case id.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/get
        /// </summary>
        public async Task<byte[]> Get(string pPlanId, string pSuiteId, string pCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"_apis/test/Plans/{pPlanId}/suites/{pSuiteId}/testcases/{pCaseId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Get all test cases in a suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/list
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> List(string pPlanId, string pSuiteId, string pCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"_apis/test/Plans/{pPlanId}/suites/{pSuiteId}/testcases/{pCaseId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Remove Test Cases From Suite Url	
        ///    The test points associated with the test cases are removed from the test suite.
        ///    The test case work item is not deleted from the system.See test cases resource to delete a test case permanently.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/remove%20test%20cases%20from%20suite%20url
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> Remove(string pPlanId, string pSuiteId, string pCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Delete, $"_apis/test/Plans/{pPlanId}/suites/{pSuiteId}/testcases/{pCaseId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Updates the properties of the test case association in a suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/update
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> Update(string pPlanId, string pSuiteId, string pCaseId)
        {
            return await Api.SendRequestAsync(ApiMethod.Post, $"_apis/test/Plans/{pPlanId}/suites/{pSuiteId}/testcases/{pCaseId}").Content.ReadAsByteArrayAsync();
        }

        #endregion
    }
}
