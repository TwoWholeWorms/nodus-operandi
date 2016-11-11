/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Data.Models.View
{

    /// <summary>
    /// Represents data on the dashboard
    /// </summary>
    public class DashboardView : AbstractViewModel
    {
        
        /// <summary>
        /// Gets or sets the number of client devices connected to the networks managed by this system
        /// </summary>
        public long NumConnectedClients { get; set; }

        /// <summary>
        /// Gets or sets the number of devices managed by this system
        /// </summary>
        public long NumDevices { get; set; }

        /// <summary>
        /// Gets or sets the number of networks managed by this system
        /// </summary>
        public long NumNetworks { get; set; }

    }

}
