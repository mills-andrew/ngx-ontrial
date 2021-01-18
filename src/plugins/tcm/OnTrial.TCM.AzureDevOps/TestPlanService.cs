using OnTrial.Api;
using System;
using System.Threading.Tasks;

namespace OnTrial.ADO
{
    /// <summary>
    /// Work with test plans programmatically using the REST APIs for Azure DevOps Services and Azure DevOps Server.
    /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans
    /// </summary>
    public class TestPlanService
    {
        #region Public Properties

        public string Route => this.Api.ToUri.ToString();
        public ApiClient Api { get; set; }

        #endregion

        #region Constructor(s)

        public TestPlanService(Uri pUri)
        {
            this.Api = new ApiClient(pUri);
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Create a test plan.
        /// </summary>
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/create
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> Create()
        {
            return await Api.SendRequestAsync(ApiMethod.Post, $"_apis/testplan/plans").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Delete a test plan.
        /// </summary>
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/delete
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public async Task<byte[]> Delete(string pPlanId)
        {
            return await Api.SendRequestAsync(ApiMethod.Delete, $"_apis/testplan/plans/{pPlanId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Get a test plan by Id.
        /// </summary>
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/get
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public async Task<byte[]> Get(string pPlanId)
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"_apis/testplan/plans/{pPlanId}").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Get a list of test plans
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/list
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public async Task<byte[]> List()
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"_apis/testplan/plans").Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Update a test plan.
        /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/update
        /// </summary>
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public async Task<byte[]> Update(string pPlanId)
        {
            return await Api.SendRequestAsync(ApiMethod.Get, $"_apis/testplan/plans/{pPlanId}").Content.ReadAsByteArrayAsync();
        }

        #endregion
    }
}
