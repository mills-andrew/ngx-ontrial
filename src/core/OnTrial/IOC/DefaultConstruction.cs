using System;
using Microsoft.Extensions.Configuration;

namespace OnTrial.IOC
{
    public class DefaultConstruction : BaseConstruction
    {
        #region Constructor(s)

        /// <summary>
        /// Default constructor
        /// </summary>
        public DefaultConstruction()
        {
            this.AddDefaultConfiguration();
        }

        /// <summary>
        /// Constructor with configuration options
        /// </summary>
        public DefaultConstruction(Action<IConfigurationBuilder> configure)
        {
            this.AddDefaultConfiguration(configure);
        }

        #endregion
    }
}
