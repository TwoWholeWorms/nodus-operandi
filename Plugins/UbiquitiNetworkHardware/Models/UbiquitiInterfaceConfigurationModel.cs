using System;
using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Models
{

    using MongoDB.Bson.Serialization.Attributes;

    public class UbiquitiInterfaceConfigurationModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the MAC address of the interface
        /// </summary>
        [BsonElementAttribute("mac")]
        public string Mac { get; set; }

        /// <summary>
        /// Gets or sets the port number of the interface
        /// </summary>
        [BsonElementAttribute("num_port")]
        public int PortNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the interface
        /// </summary>
        [BsonElementAttribute("name")]
        public string Name { get; set; }

    }

}
