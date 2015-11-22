/**
 * Based on Nancy.Demo.Samples.Data.IDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data
{
    
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retrieving and storing <see cref="AbstractNodusOperandiModel"/> instances in
    /// an underlying data store.
    /// </summary>
    public interface IClientRepository : INodusOperandiRepository
    {

        /// <summary>
        /// Gets all the demos in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="ClientModel"/> instances.</returns>
        IEnumerable<ClientModel> GetAll();

        long GetConnectedCount();
        IEnumerable<ClientModel> GetConnected(bool goByUptime);

    }

}
