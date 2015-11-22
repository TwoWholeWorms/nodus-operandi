/**
 * Based on Nancy.Demo.Samples.Data.MongoDbDemoRepository by Andreas Håkansson
 */
using System.Net.NetworkInformation;

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
            this.collection = database.GetCollection<DeviceModel>("NodusOperandiDevices");
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
            collection.Save(device);
        }

        public DeviceModel GetByManufacturerAndSerialNumber(string manufacturer, string serialNumber)
        {
            return this.collection.FindOne(Query<DeviceModel>.Where(device => device.Manufacturer == manufacturer && device.SerialNumber == serialNumber));
        }

        public DeviceModel GetByMacAddress(string macAddress)
        {
            return this.collection.FindOne(Query<DeviceModel>.Where(device => device.MacAddress == macAddress));
        }

        public DeviceModel GetByIpv4Address(string ipv4Address)
        {
            return this.collection.FindOne(Query<DeviceModel>.Where(device => device.Ipv4Address == ipv4Address));
        }

        public DeviceModel GetByIpv6Address(string ipv6Address)
        {
            return this.collection.FindOne(Query<DeviceModel>.Where(device => device.Ipv6Address == ipv6Address));
        }

        /// <summary>
        /// Gets the number of connected devices
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="DeviceModel"/> instances.</returns>
        public long GetConnectedCount()
        {
            return this.collection.Find(Query<DeviceModel>.Where(device => device.IsActive && !device.IsDeleted)).Count();
        }

        /// <summary>
        /// Gets the number of connected clients
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="DeviceModel"/> instances.</returns>
        public IEnumerable<DeviceModel> GetConnected(bool goByUptime)
        {
            return goByUptime
                    ? this.collection.Find(Query<DeviceModel>.Where(device => device.IsActive && !device.IsDeleted && device.UptimeStartedAt != null))
                    : this.collection.Find(Query<DeviceModel>.Where(device => device.IsActive && !device.IsDeleted && device.LastPingStatus == IPStatus.Success));
        }

    }

}
