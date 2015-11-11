using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Data
{

    using NLog;
    using System;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using Models;

    /// <summary>
    /// MongoDB based implementation of the <see cref="IUbiquitiDeviceRepository"/> interface.
    /// </summary>
    public class MongoDbUbiquitiDeviceRepository : IUbiquitiDeviceRepository
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly MongoCollection<UbiquitiDeviceModel> collection;

        public MongoDbUbiquitiDeviceRepository(MongoDatabase database)
        {
            this.collection = database.GetCollection<UbiquitiDeviceModel>("device");
            int c = 0;
            foreach (var device in collection.FindAll()) {
                c++;
            }
            logger.Debug("Device collection contains {0} records", c);
        }

        /// <summary>
        /// Gets all the devices in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="UbiquitiDeviceModel"/> instances.</returns>
        public IEnumerable<UbiquitiDeviceModel> GetAll()
        {
            return this.collection.FindAll();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Persist(AbstractNodusOperandiModel model)
        {
            throw new System.NotImplementedException();
        }


    }

}
