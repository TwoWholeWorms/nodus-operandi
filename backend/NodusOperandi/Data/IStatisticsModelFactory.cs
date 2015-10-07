namespace NodusOperandi.Data
{

    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retreiving information about the available statistics for network devices
    /// </summary>
    public interface IStatisticsModelFactory
    {

        /// <summary>
        /// Pulls statistics from the source systems
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, containing <see cref="StatisticsModel"/> instances.</returns>
        IEnumerable<StatisticsModel> Discover();
    
    }

}
