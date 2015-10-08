/**
 * Based on Nancy.Demo.Samples.Data.IDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data
{
    
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retrieving and storing <see cref="AbstractNodusOperandiModel"/> instances in
    /// an underlying data store.
    /// </summary>
    public interface ISettingRepository : INodusOperandiRepository
    {

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="SettingModel"/> instances.</returns>
        IEnumerable<SettingModel> GetAll();

        /// <summary>
        /// Gets all settings for a section
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="SettingModel"/> instances.</returns>
        IEnumerable<SettingModel> GetBySection(string section);

        /// <summary>
        /// Gets a setting from the database by the setting section and key
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <param name="key">The name of the key.</param>
        /// <returns>A <see cref="SettingModel"/> instance, or null.</returns>
        SettingModel GetBySectionAndKey(string section, string key);

    }

}
