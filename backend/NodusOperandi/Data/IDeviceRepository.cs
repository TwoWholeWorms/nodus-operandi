/**
 * Based on Nancy.Demo.Samples.Data.IDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data
{
    
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retrieving and storing <see cref="DeviceModel"/> instances in
    /// an underlying data store.
    /// </summary>
    public interface IDeviceRepository : INodusOperandiRepository
    {

        /// <summary>
        /// Gets a device from the database by its MAC address
        /// </summary>
        /// <param name="macAddress">The MAC address of the entity to find from the database.</param>
        /// <returns>A <see cref="DeviceModel"/> instance, or null.</returns>
        DeviceModel GetByMacAddress(string macAddress);

        /// <summary>
        /// Gets a device in the database by its IPv4 address
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address of the entity to find from the database.</param>
        /// <returns>A <see cref="DeviceModel"/> instance, or null.</returns>
        DeviceModel GetByIpv4Address(string ipv4Address);

        /// <summary>
        /// Gets a device in the database by its IPv6 address
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address of the entity to find from the database.</param>
        /// <returns>A <see cref="DeviceModel"/> instance, or null.</returns>
        DeviceModel GetByIpv6Address(string ipv6Address);

        /// <summary>
        /// Gets all the demos in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="DeviceModel"/> instances.</returns>
        IEnumerable<DeviceModel> GetAll();

    }

}
