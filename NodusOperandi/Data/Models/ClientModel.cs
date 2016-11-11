/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */
using System.Net.NetworkInformation;

namespace NodusOperandi.Data.Models
{

    using System;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class ClientModel : AbstractModel
    {

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 address of the device
        /// </summary>
        public string Ipv4Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 address of the device
        /// </summary>
        public string Ipv6Address { get; set; }

        /// <summary>
        /// Gets or sets the hostname of the device
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets when the entity was last seen on the network
        /// </summary>
        public DateTime LastSeenAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp from which to calculate the device's uptime
        /// </summary>
        public DateTime? UptimeStartedAt { get; set; }

        /// <summary>
        /// Gets or sets the last ping status of the device
        /// </summary>
        public IPStatus LastPingStatus { get; set; }

    }

}
