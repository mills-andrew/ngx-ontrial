using OnTrial.Api;
using OnTrial.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OnTrial.ADO
{
    /// <summary>
    /// Test suites help in organizing test cases in a test plan. A test suite can contain child test suites, 
    /// helping you build a folder structure under a test plan or it can contain test cases. Leaf test suites typically contain test cases, 
    /// where are intermediate suites represent a folder hierarchy. 
    /// Intermediate suites can on Static type, whereas leaf suites can be of static suites, requirement based suites or query based suites.
    /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites?view=azure-devops-rest-6.0"/>
    /// </summary>
    public class TestSuiteService
    {
        #region Public Properties

        public string Route => this.client.ToUri.ToString();

        #endregion

        #region Private Variable(s)

        private ApiClient client;

        #endregion

        #region Constructor(s)

        public TestSuiteService(string pUrl, string pOrganization, string pProject)
        {
            this.client = new ApiClient($"{pUrl}/{pOrganization}/{pProject}/");
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Add test cases to suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/add?view=azure-devops-rest-6.0
        /// </summary>
        public HttpResponseMessage Add(int? pPlanId, int? pSuiteId, int? pTestCaseId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null or empty", nameof(pPlanId));

                if (pSuiteId is null)
                    throw new ArgumentNullException($"'{nameof(pSuiteId)}' cannot be null or empty", nameof(pSuiteId));

                if (pTestCaseId is null)
                    throw new ArgumentException($"'{nameof(pTestCaseId)}' cannot be null or empty", nameof(pTestCaseId));

                return client.SendRequestAsync(ApiMethod.Post, $"{pPlanId}/suites/{pSuiteId}/testcases/{pTestCaseId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get a specific test case in a test suite with test case id.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/get?view=azure-devops-rest-6.0
        /// </summary>
        public HttpResponseMessage Get(int? pPlanId, int? pSuiteId, int? pTestCaseId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null or empty", nameof(pPlanId));

                if (pSuiteId is null)
                    throw new ArgumentNullException($"'{nameof(pSuiteId)}' cannot be null or empty", nameof(pSuiteId));

                if (pTestCaseId is null)
                    throw new ArgumentException($"'{nameof(pTestCaseId)}' cannot be null or empty", nameof(pTestCaseId));

                return client.SendRequestAsync(ApiMethod.Post, $"{pPlanId}/suites/{pSuiteId}/testcases/{pTestCaseId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get all test cases in a suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/list?view=azure-devops-rest-6.0
        /// </summary>
        public IList<HttpResponseMessage> List(int? pPlanId, int? pSuiteId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null or empty", nameof(pPlanId));

                if (pSuiteId is null)
                    throw new ArgumentNullException($"'{nameof(pSuiteId)}' cannot be null or empty", nameof(pSuiteId));

                return client.SendRequestAsync(ApiMethod.Get, $"{pPlanId}/suites/{pSuiteId}/testcases").ToEntityList<HttpResponseMessage>();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// The test points associated with the test cases are removed from the test suite. 
        /// The test case work item is not deleted from the system.See test cases resource to delete a test case permanently.
        /// </summary>
        /// <param name="pUrl"></param>
        public HttpResponseMessage Remove(int? pPlanId, int? pSuiteId, int? pTestCaseId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null or empty", nameof(pPlanId));

                if (pSuiteId is null)
                    throw new ArgumentNullException($"'{nameof(pSuiteId)}' cannot be null or empty", nameof(pSuiteId));

                if (pTestCaseId is null)
                    throw new ArgumentException($"'{nameof(pTestCaseId)}' cannot be null or empty", nameof(pTestCaseId));

                return client.SendRequestAsync(ApiMethod.Delete, $"{pPlanId}/suites/{pSuiteId}/testcases/{pTestCaseId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the properties of the test case association in a suite.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/test/test%20%20suites/update?view=azure-devops-rest-6.0
        /// </summary>
        public HttpResponseMessage Update(int? pPlanId, int? pSuiteId, int? pTestCaseId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null or empty", nameof(pPlanId));

                if (pSuiteId is null)
                    throw new ArgumentNullException($"'{nameof(pSuiteId)}' cannot be null or empty", nameof(pSuiteId));

                if (pTestCaseId is null)
                    throw new ArgumentException($"'{nameof(pTestCaseId)}' cannot be null or empty", nameof(pTestCaseId));

                return client.SendRequestAsync(ApiMethod.Put, $"{pPlanId}/suites/{pSuiteId}/testcases/{pTestCaseId}");
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
