using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace OnTrial
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection Remove<T>(this IServiceCollection pServices)
        {
            var serviceDescriptor = pServices.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            if (serviceDescriptor != null) pServices.Remove(serviceDescriptor);

            return pServices;
        }
    }
}
