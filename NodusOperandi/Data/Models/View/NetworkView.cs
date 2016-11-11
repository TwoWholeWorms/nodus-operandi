/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Data.Models.View
{

    /// <summary>
    /// Represents data on the dashboard
    /// </summary>
    public class NetworkView : AbstractViewModel
    {

        /// <summary>
        /// Gets or sets the configured networks to display
        /// </summary>
        public Network[] Networks { get; set; }

    }

}
