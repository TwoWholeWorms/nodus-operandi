namespace NodusOperandi.Data
{

    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retreiving information about the available alerts for network devices
    /// </summary>
    public interface IAlertModelFactory
    {

        /// <summary>
        /// Pulls alerts from the source systems
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, containing <see cref="AlertModel"/> instances.</returns>
        IEnumerable<AlertModel> Discover();
    
    }

}
