/**
 * Based on Nancy.Demo.Samples.Data.IDemoRepository by Andreas Håkansson
 */

using NodusOperandi.Data;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retrieving and storing <see cref="UbiquitiDeviceModel"/> instances in
    /// an underlying data store.
    /// </summary>
    public interface IUbiquitiDeviceRepository : INodusOperandiRepository
    {

        /// <summary>
        /// Gets all the demos in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="UbiquitiDeviceModel"/> instances.</returns>
        IEnumerable<UbiquitiDeviceModel> GetAll();

    }

}
