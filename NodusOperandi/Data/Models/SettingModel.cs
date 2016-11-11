/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Data.Models
{

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class SettingModel : AbstractModel
    {

        /// <summary>
        /// Gets or sets the setting section
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the setting key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the setting value
        /// </summary>
        public string Value { get; set; }

    }

}
