using System;
using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Models
{

    using MongoDB.Bson.Serialization.Attributes;

    public class UbiquitiRadioConfigurationModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the radio bands
        /// </summary>
        [BsonElementAttribute("radio")]
        public string Bands { get; set; }

        /// <summary>
        /// Gets or sets the name of the interface
        /// </summary>
        [BsonElementAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the radio channel
        /// </summary>
        [BsonElementAttribute("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the radio HT value
        /// </summary>
        [BsonElementAttribute("ht")]
        public string Ht { get; set; }

        /// <summary>
        /// Gets or sets the radio power mode
        /// </summary>
        [BsonElementAttribute("tx_power_mode")]
        public string TxPowerMode { get; set; }

        /// <summary>
        /// Gets or sets the radio power level
        /// </summary>
        [BsonElementAttribute("tx_power")]
        public string TxPower { get; set; }

        /// <summary>
        /// Gets or sets the radio's max power level
        /// </summary>
        [BsonElementAttribute("max_txpower")]
        public int TxMaxPower { get; set; }

        /// <summary>
        /// Gets or sets the radio's min power level
        /// </summary>
        [BsonElementAttribute("min_txpower")]
        public int TxMinPower { get; set; }

        /// <summary>
        /// Gets or sets whether the antenna is built-in or external
        /// </summary>
        [BsonElementAttribute("builtin_antenna")]
        public bool BuiltInAntenna { get; set; }

        /// <summary>
        /// Gets or sets the gain on the built-in antenna
        /// </summary>
        [BsonElementAttribute("builtin_ant_gain")]
        public int BuiltInAntennaGain { get; set; }

        /// <summary>
        /// Gets or sets the gain on the antenna
        /// </summary>
        [BsonElementAttribute("antenna_gain")]
        public int AntennaGain { get; set; }

    }

}
