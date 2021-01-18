using Microsoft.Extensions.DependencyInjection;
using System;

namespace OnTrial.IOC
{
    public static class Framework
    {
        public static BaseConstruction Construction { get; private set; }
        public static IServiceProvider Provider => Construction?.Provider;

        #region Extension Methods

        /// <summary>
        /// Should be called once a Framework Construction is finished and we want to build it and
        /// start our application in a hosted environment where the service provider is already built
        /// such as ASP.Net Core applications
        /// </summary>
        /// <param name="pProvider">The provider</param>
        public static void Build(IServiceProvider pProvider)
        {
            // Build the service provider
            Construction.Build(pProvider);
        }

        /// <summary>
        /// The initial call to setting up and using the Framework
        /// </summary>
        /// <typeparam name="T">The type of construction to use</typeparam>
        public static BaseConstruction Construct()
        {
            Construction = Construction ?? new DefaultConstruction();
            return Construction;
        }

        /// <summary>
        /// The initial call to setting up and using the Framework
        /// </summary>
        /// <typeparam name="T">The type of construction to use</typeparam>
        public static BaseConstruction Construct<T>() where T : BaseConstruction, new()
        {
            Construction = new T();
            return Construction;
        }


        /// <summary>
        /// The initial call to setting up and using the Framework.
        /// </summary>
        /// <typeparam name="T">The type of construction to use</typeparam>
        /// <param name="constructionInstance">The instance of the construction to use</param>
        public static BaseConstruction Construct<T>(T constructionInstance) where T : BaseConstruction
        {
            Construction = constructionInstance;
            return Construction;
        }

        /// <summary>
        /// Shortcut to Framework.Provider.GetService to get an injected service of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of service to get</typeparam>
        /// <returns></returns>
        public static T Service<T>()
        {
            return Provider.GetService<T>();
        }

        #endregion
    }
}
