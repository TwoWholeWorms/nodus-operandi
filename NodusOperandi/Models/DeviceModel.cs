/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Models
{

    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class DeviceModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        public string macAddress { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 address of the device
        /// </summary>
        public string Ipv4Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 address of the device
        /// </summary>
        public string Ipv6Address { get; set; }

    }

}
