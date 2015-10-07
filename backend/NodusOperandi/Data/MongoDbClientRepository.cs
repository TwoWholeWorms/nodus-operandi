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
    /// MongoDB based implementation of the <see cref="IClientRepository"/> interface.
    /// </summary>
    public class MongoDbClientRepository : IClientRepository
    {

        private readonly MongoCollection<ClientModel> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDeviceRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbClientRepository(MongoDatabase database)
        {
            this.collection = database.GetCollection<ClientModel>(Configuration.DatabaseName);
        }

        /// <summary>
        /// Deletes all devices.
        /// </summary>
        public void DeleteAll()
        {
            this.collection.Drop();
        }

        /// <summary>
        /// Deletes a client by its id
        /// </summary>
        /// <param name="id">The id of the device to delete from the database.</param>
        public void DeleteById(string id)
        {
            this.collection.Remove(Query<ClientModel>.Where(device => device.Id == id));
        }

        /// <summary>
        /// Gets all the clients in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="ClientModel"/> instances.</returns>
        public IEnumerable<ClientModel> GetAll()
        {
            return this.collection.FindAll();
        }

        /// <summary>
        /// Persists a new client in the data store.
        /// </summary>
        /// <param name="client">The <see cref="ClientModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel client)
        {
            collection.Insert(client);
        }

    }

}
