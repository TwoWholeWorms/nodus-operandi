/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Models
{

    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Represents data on the dashboard
    /// </summary>
    public class DashboardModel : AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the number of connected clients
        /// </summary>
        public long NumConnectedClients { get; set; }

        /// <summary>
        /// Gets or sets the number of connected devices
        /// </summary>
        public long NumConnectedDevices { get; set; }

    }

}
