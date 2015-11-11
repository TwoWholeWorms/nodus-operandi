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
        /// Gets or sets the manufacturer of the device
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model of the device
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the firmware version of the device
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the serial number of the device
        /// </summary>
        public string SerialNumber { get; set; }

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

    }

}
