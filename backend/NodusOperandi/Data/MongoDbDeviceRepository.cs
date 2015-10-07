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
    /// MongoDB based implementation of the <see cref="IDeviceRepository"/> interface.
    /// </summary>
    public class MongoDbDeviceRepository : IDeviceRepository
    {

        private readonly MongoCollection<DeviceModel> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDeviceRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbDeviceRepository(MongoDatabase database)
        {
            this.collection = database.GetCollection<DeviceModel>(Configuration.DatabaseName);
        }

        /// <summary>
        /// Deletes all devices.
        /// </summary>
        public void DeleteAll()
        {
            this.collection.Drop();
        }

        /// <summary>
        /// Deletes a device by its id
        /// </summary>
        /// <param name="id">The id of the device to delete from the database.</param>
        public void DeleteById(string id)
        {
            this.collection.Remove(Query<DeviceModel>.Where(device => device.Id == id));
        }

        /// <summary>
        /// Gets all the devices in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="DeviceModel"/> instances.</returns>
        public IEnumerable<DeviceModel> GetAll()
        {
            return this.collection.FindAll();
        }

        /// <summary>
        /// Persists a new device in the data store.
        /// </summary>
        /// <param name="device">The <see cref="DeviceModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel device)
        {
            collection.Insert(device);
        }

        public DeviceModel GetByMacAddress(string macAddress)
        {
            throw new System.NotImplementedException();
        }

        public DeviceModel GetByIpv4Address(string ipv4Address)
        {
            throw new System.NotImplementedException();
        }

        public DeviceModel GetByIpv6Address(string ipv6Address)
        {
            throw new System.NotImplementedException();
        }

    }

}
