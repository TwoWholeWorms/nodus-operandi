/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Models
{

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class UbiquitiSiteModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the device
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the hidden id of the device
        /// </summary>
        public string HiddenId { get; set; }

        /// <summary>
        /// Gets or sets whether the site is hidden
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets whether the site is deletable
        /// </summary>
        public bool IsUndeletable { get; set; }

        /// <summary>
        /// Gets or sets whether the site is editable
        /// </summary>
        public bool IsUneditable { get; set; }

    }

}
