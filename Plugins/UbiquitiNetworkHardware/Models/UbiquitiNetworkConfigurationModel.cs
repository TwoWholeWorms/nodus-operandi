using System;
using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Models
{

    using MongoDB.Bson.Serialization.Attributes;
    
    public class UbiquitiNetworkConfigurationModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the type of network configuration
        /// </summary>
        [BsonElementAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the IP of the network configuration
        /// </summary>
        [BsonElementAttribute("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the netmask of the network configuration
        /// </summary>
        [BsonElementAttribute("netmask")]
        public string Netmask { get; set; }

        /// <summary>
        /// Gets or sets the gateway of the network configuration
        /// </summary>
        [BsonElementAttribute("gateway")]
        public string Gateway { get; set; }

        /// <summary>
        /// Gets or sets the primary DNS of the network configuration
        /// </summary>
        [BsonElementAttribute("dns1")]
        public string Dns1 { get; set; }

        /// <summary>
        /// Gets or sets the secondary DNS of the network configuration
        /// </summary>
        [BsonElementAttribute("dns2")]
        public string Dns2 { get; set; }

        /// <summary>
        /// Gets or sets the DNS suffix of the network configuration
        /// </summary>
        [BsonElementAttribute("dnssuffix")]
        public string DnsSuffix { get; set; }

    }

}
