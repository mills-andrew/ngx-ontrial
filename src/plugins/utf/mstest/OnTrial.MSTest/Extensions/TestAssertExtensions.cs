using Microsoft.Extensions.DependencyInjection;
using OnTrial.IOC;

namespace OnTrial.MSTest
{
    public static class TestAssertExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConstruction"></param>
        /// <returns></returns>
        public static BaseConstruction AddMSTestAssert(this BaseConstruction pConstruction)
        {
            Framework.Construct().Services.AddScoped<IAssert>(m=>new MSTestAssert());
            return pConstruction;
        }
    }
}
