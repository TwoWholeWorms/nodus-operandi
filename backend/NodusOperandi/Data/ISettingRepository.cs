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
        /// Gets all the demos in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="SettingModel"/> instances.</returns>
        IEnumerable<SettingModel> GetAll();
        
        /// <summary>
        /// Gets a list of settings from the database by the setting section
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <returns>A <see cref="SettingModel"/> instance, or null.</returns>
        SettingModel GetByMacAddress(string section);

    }

}
