using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;

namespace OnTrial.Workflow.Desktop
{
    /// <summary>
    /// Author: Andrew Mills
    /// </summary>
    public static class DesktopConstructionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConstruction"></param>
        /// <returns></returns>
        public static BaseConstruction UseDefaultDesktopBehavior(this BaseConstruction pConstruction)
        {
            pConstruction.Services.AddScoped<WorkflowPlugin, DefaultWorkflowPlugin>();
            return pConstruction;
        }
    }
}
