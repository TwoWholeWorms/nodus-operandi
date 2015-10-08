namespace NodusOperandi.Data
{

    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retreiving information about the available devices on the network
    /// </summary>
    public interface IDeviceModelFactory
    {

        /// <summary>
        /// Discovers devices on the network
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, containing <see cref="DeviceModel"/> instances.</returns>
        IEnumerable<DeviceModel> Discover();
    
    }

}
