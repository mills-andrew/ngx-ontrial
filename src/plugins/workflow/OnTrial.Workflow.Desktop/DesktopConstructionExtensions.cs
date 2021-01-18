using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;

namespace OnTrial.Workflow.Desktop
{
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
