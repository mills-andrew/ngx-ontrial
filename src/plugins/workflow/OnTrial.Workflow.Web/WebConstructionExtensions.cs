using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;

namespace OnTrial.Workflow.Web
{
    /// <summary>
    /// Author: Andrew Mills
    /// </summary>
    public static class WebConstructionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConstruction"></param>
        /// <returns></returns>
        public static BaseConstruction UseDefaultWebBehavior(this BaseConstruction pConstruction)
        {
            pConstruction.Services.AddScoped<WorkflowPlugin, DefaultWorkflowPlugin>();
            return pConstruction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConstruction"></param>
        /// <returns></returns>
        public static BaseConstruction UseSeleniumWebBehavior(this BaseConstruction pConstruction)
        {
            pConstruction.Services.AddScoped<WorkflowPlugin, SeleniumWorkflowPlugin>();
            return pConstruction;
        }
    }
}