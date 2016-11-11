/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Data.Models
{

    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class AlertModel : AbstractModel
    {

        /// <summary>
        /// Gets or sets the content of the alert
        /// </summary>
        public string Content { get; set; }

    }

}
