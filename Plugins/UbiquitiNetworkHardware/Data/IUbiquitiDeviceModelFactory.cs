namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retreiving information about the available devices on the network
    /// </summary>
    public interface IUbiquitiDeviceModelFactory
    {

        /// <summary>
        /// Discovers devices on the network
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, containing <see cref="UbiquitiDeviceModel"/> instances.</returns>
        IEnumerable<UbiquitiDeviceModel> Discover();

    }

}
