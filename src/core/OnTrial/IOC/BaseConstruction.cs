using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnTrial.IOC
{
    public class BaseConstruction
    {
        #region Protected Members

        /// <summary>
        /// The services that will get used and compiled once the framework is built
        /// </summary>
        protected IServiceCollection mServices;

        #endregion

        #region Public Properties

        /// <summary>
        /// The services that will get used and compiled once the framework is built
        /// </summary>
        public IServiceCollection Services
        {
            get => mServices;
            set
            {
                // Set services
                mServices = value;

                // If we have some...
                if (mServices != null)
                    // Inject environment into services
                    Services.AddSingleton(Environment);
            }
        }

        /// <summary>
        /// The dependency injection service provider
        /// </summary>
        public IServiceProvider Provider { get; protected set; }

        /// <summary>
        /// The environment used for the Framework
        /// </summary>
        public IEnviornment Environment { get; protected set; }

        /// <summary>
        /// The configuration used for the Framework
        /// </summary>
        public IConfiguration Configuration { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="createServiceCollection">If true, a new <see cref="ServiceCollection"/> will be created for the Services</param>
        public BaseConstruction(bool createServiceCollection = true)
        {
            // Create environment details
            Environment = new DefaultEnvironment();

            // If we should create the service collection then Create a new list of dependencies
            if (createServiceCollection)
                Services = new ServiceCollection();
        }

        #endregion

        #region Build Methods

        /// <summary>
        /// Builds the service collection into a service provider
        /// </summary>
        public void Build(IServiceProvider provider = null)
        {
            // Use given provider or build it
            Provider = provider ?? Services.BuildServiceProvider();
        }

        #endregion

        #region Hosted Environment Methods

        /// <summary>
        /// Uses the given service collection in the framework. 
        /// Typically used in an ASP.Net Core environment where
        /// the ASP.Net server has its own collection.
        /// </summary>
        /// <param name="services">The services to use</param>
        /// <returns></returns>
        public BaseConstruction UseHostedServices(IServiceCollection services)
        {
            Services = services;
            return this;
        }

        /// <summary>
        /// Uses the given configuration in the framework
        /// </summary>
        /// <param name="configuration">The configuration to use</param>
        /// <returns></returns>
        public BaseConstruction UseConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
            return this;
        }

        #endregion
    }
}
