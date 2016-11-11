/**
 * Based on Nancy.Demo.Samples.Data.MongoDbDemoRepository by Andreas Håkansson
 */
using System.Net.NetworkInformation;

namespace NodusOperandi.Data.MongoDb
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
        /// Initializes a new instance of the <see cref="MongoDbClientRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbClientRepository(MongoDatabase database)
        {
            collection = database.GetCollection<ClientModel>("NodusOperandiClients");
        }

        /// <summary>
        /// Deletes all clients.
        /// </summary>
        public void DeleteAll()
        {
            collection.Drop();
        }

        /// <summary>
        /// Deletes a client by its id
        /// </summary>
        /// <param name="id">The id of the client to delete from the database.</param>
        public void DeleteById(string id)
        {
            collection.Remove(Query<ClientModel>.Where(client => client.Id == id));
        }

        /// <summary>
        /// Gets all the clients in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="ClientModel"/> instances.</returns>
        public IEnumerable<ClientModel> GetAll()
        {
            return collection.FindAll();
        }

        /// <summary>
        /// Persists a new client in the data store.
        /// </summary>
        /// <param name="client">The <see cref="ClientModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel client)
        {
            collection.Save(client);
        }

        public ClientModel GetByMacAddress(string macAddress)
        {
            return collection.FindOne(Query<ClientModel>.Where(client => client.MacAddress == macAddress));
        }

        public ClientModel GetByIpv4Address(string ipv4Address)
        {
            return collection.FindOne(Query<ClientModel>.Where(client => client.Ipv4Address == ipv4Address));
        }

        public ClientModel GetByIpv6Address(string ipv6Address)
        {
            return collection.FindOne(Query<ClientModel>.Where(client => client.Ipv6Address == ipv6Address));
        }

        /// <summary>
        /// Gets the number of connected clients
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="ClientModel"/> instances.</returns>
        public long GetConnectedCount()
        {
            return collection.Find(Query<ClientModel>.Where(client => client.IsActive && !client.IsDeleted && client.LastPingStatus == IPStatus.Success)).Count();
        }

        /// <summary>
        /// Gets the number of connected clients
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="ClientModel"/> instances.</returns>
        public IEnumerable<ClientModel> GetConnected(bool goByUptime)
        {
            return goByUptime
                    ? collection.Find(Query<ClientModel>.Where(client => client.IsActive && !client.IsDeleted && client.UptimeStartedAt != null))
                    : collection.Find(Query<ClientModel>.Where(client => client.IsActive && !client.IsDeleted && client.LastPingStatus == IPStatus.Success));
        }

    }

}
