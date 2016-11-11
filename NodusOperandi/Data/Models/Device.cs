/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */
namespace NodusOperandi.Data.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net.NetworkInformation;
    using System.Collections.Generic;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    [Table("Device")]
    public class Device : AbstractModel
    {

        /// <summary>
        /// Gets or sets the parent device id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CSS icon class for the device
        /// </summary>
        public string Icon { get; set; }

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

        /// <summary>
        /// Gets or sets the name of the plugin assembly which handles communication with this device
        /// </summary>
        public string PluginAssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the class which handles communication with this device
        /// </summary>
        public string PluginClass { get; set; }

        /// <summary>
        /// Gets or sets the name of the method which handles communication with this device
        /// </summary>
        public string PluginClassMethod { get; set; }

        /// <summary>
        /// Gets or sets the data which the plugin uses to control the device (eg, internal device ids, etc)
        /// </summary>
        public Dictionary<string, string> PluginControlData { get; set; }

    }

}
