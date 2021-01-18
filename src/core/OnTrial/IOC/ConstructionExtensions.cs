using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnTrial.IOC
{
    public static class ConstructionExtensions
    {
        /// <summary>
        /// Configures a framework construction in the default way
        /// </summary>
        /// <param name="pConstruction">The construction to configure</param>
        /// <param name="pConfigure">The custom configuration action</param>
        /// <returns></returns>
        public static BaseConstruction AddDefaultConfiguration(this BaseConstruction pConstruction, Action<IConfigurationBuilder> pConfigure = null)
        {
            // Create our configuration sources
            var configurationBuilder = new ConfigurationBuilder().AddEnvironmentVariables();

            // If we are not on a mobile platform...
            if (!pConstruction.Environment.IsMobile)
            {
                // Add file based configuration

                // Set base path for Json files as the startup location of the application
                configurationBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                // Add application settings json files
                configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddJsonFile($"appsettings.{pConstruction.Environment.Configuration}.json", optional: true, reloadOnChange: true);
            }

            // Let custom configuration happen
            pConfigure?.Invoke(configurationBuilder);

            // Inject configuration into services
            var configuration = configurationBuilder.Build();
            pConstruction.Services.AddSingleton<IConfiguration>(configuration);

            // Set the construction Configuration
            pConstruction.UseConfiguration(configuration);

            // Chain the construction
            return pConstruction;
        }
    }
}
