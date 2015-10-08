namespace NodusOperandi.Data
{

    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retreiving information about the available clients on the network
    /// </summary>
    public interface IClientModelFactory
    {

        /// <summary>
        /// Discovers devices on the network
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, containing <see cref="ClientModel"/> instances.</returns>
        IEnumerable<ClientModel> Discover();
    
    }

}
