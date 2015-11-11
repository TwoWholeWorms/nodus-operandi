/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Models
{

    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class UbiquitiDeviceModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        [BsonElementAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the adoption status of the device
        /// </summary>
        [BsonElementAttribute("adopted")]
        public bool Adopted { get; set; }

        /// <summary>
        /// Gets or sets the device's config version
        /// </summary>
        [BsonElementAttribute("cfgversion")]
        public string CfgVersion { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        [BsonElementAttribute("config_network")]
        public UbiquitiNetworkConfigurationModel NetworkConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        [BsonElementAttribute("config_network_wan")]
        public UbiquitiNetworkConfigurationModel NetworkConfigurationWan { get; set; }

        /// <summary>
        /// Gets or sets the network interfaces list
        /// </summary>
        [BsonElementAttribute("ethernet_table")]
        public List<UbiquitiInterfaceConfigurationModel> Interfaces { get; set; } = new List<UbiquitiInterfaceConfigurationModel>();

        /// <summary>
        /// Gets or sets the inform IP address
        /// </summary>
        [BsonElementAttribute("inform_ip")]
        public string InformIp { get; set; }

        /// <summary>
        /// Gets or sets the inform URL
        /// </summary>
        [BsonElementAttribute("inform_url")]
        public string InformUrl { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        [BsonElementAttribute("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the MAC address
        /// </summary>
        [BsonElementAttribute("mac")]
        public string Mac { get; set; }

        /// <summary>
        /// Gets or sets the map ID
        /// </summary>
        [BsonElementAttribute("map_id")]
        public string MapId { get; set; }

        /// <summary>
        /// Gets or sets the device model
        /// </summary>
        [BsonElementAttribute("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the serial number
        /// </summary>
        [BsonElementAttribute("serial")]
        public string Serial { get; set; }

        /// <summary>
        /// Gets or sets the site id the device belongs to
        /// </summary>
        [BsonElementAttribute("site_id")]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the site the device belongs to
        /// </summary>
        public UbiquitiSiteModel Site { get; set; }

        /// <summary>
        /// Gets or sets the device type
        /// </summary>
        [BsonElementAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the device's firmware version
        /// </summary>
        [BsonElementAttribute("version")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate
        /// </summary>
        [BsonElementAttribute("x")]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the device's X authkey?!
        /// </summary>
        [BsonElementAttribute("x_authkey")]
        public string XAuthkey { get; set; }

        /// <summary>
        /// Gets or sets the device's X fingerprint?!
        /// </summary>
        [BsonElementAttribute("x_fingerprint")]
        public string XFingerprint { get; set; }

        /// <summary>
        /// Gets or sets the device's Y coordinate
        /// </summary>
        [BsonElementAttribute("y")]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the radio list
        /// </summary>
        [BsonElementAttribute("radio_table")]
        public List<UbiquitiRadioConfigurationModel> Radios { get; set; } = new List<UbiquitiRadioConfigurationModel>();

        /// <summary>
        /// Gets or sets the vwire list
        /// </summary>
        [BsonElementAttribute("vwire_table")]
        public List<UbiquitiVWireModel> VWires { get; set; } = new List<UbiquitiVWireModel>();

        /// <summary>
        /// Gets or sets the WLAN overrides list
        /// </summary>
        [BsonElementAttribute("wlan_overrides")]
        public List<UbiquitiWlanOverrideModel> WlanOverrides { get; set; } = new List<UbiquitiWlanOverrideModel>();

        /// <summary>
        /// Gets or sets the device's na WLAN group ID
        /// </summary>
        [BsonElementAttribute("wlangroup_id_na")]
        public string WlanGroupIdNa { get; set; }

        /// <summary>
        /// Gets or sets the device's ng WLAN group ID
        /// </summary>
        [BsonElementAttribute("wlangroup_id_ng")]
        public string WlanGroupIdNg { get; set; }

        /// <summary>
        /// Gets or sets the device's X vwire key?!
        /// </summary>
        [BsonElementAttribute("x_vwirekey")]
        public string XVwirekey { get; set; }

        /// <summary>
        /// Gets or sets the device's X vwire key?!
        /// </summary>
        [BsonElementAttribute("bandsteering_mode")]
        public string BandSteeringMode { get; set; }

    }

}
