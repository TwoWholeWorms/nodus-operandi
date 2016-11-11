/**
 * Based on Nancy.Demo.Samples.Data.MongoDbDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data.MongoDb
{
    using System.Collections.Generic;
    using Models;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB based implementation of the <see cref="ISettingRepository"/> interface.
    /// </summary>
    public class MongoDbSettingRepository : ISettingRepository
    {

        private readonly MongoCollection<SettingModel> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbSettingRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbSettingRepository(MongoDatabase database)
        {
            collection = database.GetCollection<SettingModel>(Configuration.DatabaseName);
        }

        /// <summary>
        /// Deletes all settings.
        /// </summary>
        public void DeleteAll()
        {
            collection.Drop();
        }

        /// <summary>
        /// Deletes a setting by its id
        /// </summary>
        /// <param name="id">The id of the setting to delete from the database.</param>
        public void DeleteById(string id)
        {
            collection.Remove(Query<SettingModel>.Where(setting => setting.Id == id));
        }

        /// <summary>
        /// Gets all the settings in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="SettingModel"/> instances.</returns>
        public IEnumerable<SettingModel> GetAll()
        {
            return collection.FindAll();
        }

        /// <summary>
        /// Gets all settings for a section
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="SettingModel"/> instances.</returns>
        public IEnumerable<SettingModel> GetBySection(string section)
        {
            return collection.Find(Query<SettingModel>.Where(setting => setting.Section == section));
        }

        /// <summary>
        /// Persists a new setting in the data store.
        /// </summary>
        /// <param name="setting">The <see cref="SettingModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel setting)
        {
            collection.Insert(setting);
        }

        /// <summary>
        /// Gets a setting from the database by the setting section and key
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <param name="key">The name of the key.</param>
        /// <returns>A <see cref="SettingModel"/> instance, or null.</returns>
        public SettingModel GetBySectionAndKey(string section, string key)
        {
            throw new System.NotImplementedException();
        }

    }

}
