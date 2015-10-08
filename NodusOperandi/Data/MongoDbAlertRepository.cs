/**
 * Based on Nancy.Demo.Samples.Data.MongoDbDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data
{
    using System.Collections.Generic;
    using Models;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB based implementation of the <see cref="IAlertRepository"/> interface.
    /// </summary>
    public class MongoDbAlertRepository : IAlertRepository
    {

        private readonly MongoCollection<AlertModel> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbAlertRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbAlertRepository(MongoDatabase database)
        {
            this.collection = database.GetCollection<AlertModel>(Configuration.DatabaseName);
        }

        /// <summary>
        /// Deletes all alerts.
        /// </summary>
        public void DeleteAll()
        {
            this.collection.Drop();
        }

        /// <summary>
        /// Deletes a alert by its id
        /// </summary>
        /// <param name="id">The id of the alert to delete from the database.</param>
        public void DeleteById(string id)
        {
            this.collection.Remove(Query<AlertModel>.Where(alert => alert.Id == id));
        }

        /// <summary>
        /// Gets all the alerts in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="AlertModel"/> instances.</returns>
        public IEnumerable<AlertModel> GetAll()
        {
            return this.collection.FindAll();
        }

        /// <summary>
        /// Persists a new alert in the data store.
        /// </summary>
        /// <param name="alert">The <see cref="AlertModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel alert)
        {
            collection.Insert(alert);
        }

    }

}
