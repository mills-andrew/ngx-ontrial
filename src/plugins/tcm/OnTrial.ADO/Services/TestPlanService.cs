using OnTrial.Api;
using OnTrial.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OnTrial.ADO
{
    /// <summary>
    /// Work with test plans programmatically using the REST APIs for Azure DevOps Services and Azure DevOps Server.
    /// https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans
    /// </summary>
    public class TestPlanService
    {
        #region Public Properties

        public string Route => this.client.ToUri.ToString();

        #endregion

        #region private Variable(s)

        private ApiClient client { get; set; }

        #endregion

        #region Constructor(s)

        public TestPlanService(string pUrl, string pOrganization, string pProjectId)
        {
            try
            {
                if (pUrl is null)
                    throw new ArgumentNullException(nameof(pUrl));

                if (pOrganization is null)
                    throw new ArgumentNullException(nameof(pOrganization));

                if (pProjectId is null)
                    throw new ArgumentNullException(nameof(pProjectId));

                this.client = new ApiClient($"{pUrl}/{pOrganization}/{pProjectId}/");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Operation(s)

        /// <summary>
        /// Create a test plan.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/create"/>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public HttpResponseMessage Create()
        {
            try
            {
                return client.SendRequestAsync(ApiMethod.Post, $"_apis/testplan/plans");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Delete a test plan.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/delete"/>
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(uint? pPlanId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null", nameof(pPlanId));
                
                return client.SendRequestAsync(ApiMethod.Delete, $"_apis/testplan/plans/{pPlanId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get a test plan by Id.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/get"/>
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(uint? pPlanId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null", nameof(pPlanId));

                return client.SendRequestAsync(ApiMethod.Get, $"_apis/testplan/plans/{pPlanId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get a list of test plans
        /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/list"/>
        /// </summary>
        /// <param name="pTestCaseId"></param>
        /// <returns></returns>
        public IList<HttpResponseMessage> List()
        {
            try
            {
                return client.SendRequestAsync(ApiMethod.Get, $"_apis/testplan/plans").ToEntityList<HttpResponseMessage>();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Update a test plan.
        /// <see cref="https://docs.microsoft.com/en-us/rest/api/azure/devops/testplan/test%20%20plans/update"/>
        /// </summary>
        /// <param name="pPlanId"></param>
        /// <returns></returns>
        public HttpResponseMessage Update(uint? pPlanId)
        {
            try
            {
                if (pPlanId is null)
                    throw new ArgumentNullException($"'{nameof(pPlanId)}' cannot be null", nameof(pPlanId));

                return client.SendRequestAsync(ApiMethod.Put, $"_apis/testplan/plans/{pPlanId}");
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
