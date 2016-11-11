/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Data.Models.View
{

    /// <summary>
    /// Represents data on the dashboard
    /// </summary>
    public class DeviceView : AbstractViewModel
    {

        /// <summary>
        /// Gets or sets the configured devices to display
        /// </summary>
        public Device[] Devices { get; set; }

    }

}
