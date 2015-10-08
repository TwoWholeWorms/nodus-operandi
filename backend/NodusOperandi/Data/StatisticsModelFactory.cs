namespace NodusOperandi.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="IStatisticsModelFactory"/> interface.
    /// </summary>
    public class StatisticsModelFactory : IStatisticsModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsModelFactory"/>
        /// </summary>
        public StatisticsModelFactory()
        {
            // …
        }

        #region IStatisticsModelFactory implementation
        public IEnumerable<StatisticsModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }

}
