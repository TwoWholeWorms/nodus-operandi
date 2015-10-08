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
    public class StatisticsModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the content of the alert
        /// </summary>
        public string Content { get; set; }

    }

}
