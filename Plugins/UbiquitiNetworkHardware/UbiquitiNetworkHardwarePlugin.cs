using NodusOperandi;
using NodusOperandi.Data;
using NodusOperandi.Models;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware
{

    using NLog;
    using System.IO;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using Nancy.Extensions;
    using Data;
    using Models;

    public class UbiquitiNetworkHardwarePlugin : AbstractPlugin
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        protected MongoClient mongoClient;
        protected MongoDatabase unifiDb;
        protected MongoDbUbiquitiDeviceRepository ubiquitiDeviceRepo;
        protected MongoDbDeviceRepository deviceRepo;

        #region AbstractPlugin implementation
        static UbiquitiNetworkHardwarePlugin()
        {
            PluginManager.AddPlugin(new UbiquitiNetworkHardwarePlugin());
        }

        public UbiquitiNetworkHardwarePlugin()
        {
            var config = new Configuration();

            var binDirectory = Path.GetDirectoryName(this.GetType().GetAssemblyPath());
            var configPath = Path.Combine(binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load(configPath, config);

            mongoClient = new MongoClient(Configuration.UniFiMongoDbConnectionString);
            var mongoServer = mongoClient.GetServer();
            unifiDb = mongoServer.GetDatabase(Configuration.UniFiDatabaseName);
            ubiquitiDeviceRepo = new MongoDbUbiquitiDeviceRepository(unifiDb);
        }
        
        public override string Name {
            get {
                return "Ubiquiti Network Hardware Plugin";
            }
        }

        public override void RegisterPlugin()
        {
            PluginManager.ProcessHeartbeat += DoHeartbeat;
            PluginManager.DetectNewDevices += DetectNewDevices;
        }

        public void DoHeartbeat()
        {
            // …
        }

        public void DetectNewDevices()
        {
            if (null == deviceRepo) {
                if (null == Bootstrapper.mongoDb) {
                    logger.Debug("Core not connected to MongoDB yet");
                    return;
                }
                deviceRepo = new MongoDbDeviceRepository(Bootstrapper.mongoDb);
            }

            // logger.Debug("Getting Ubiquiti devices from UniFi MongoDB");
            var devices = ubiquitiDeviceRepo.GetAll();

            foreach (var d in devices) {
                DeviceModel device = deviceRepo.GetByManufacturerAndSerialNumber("Ubiquiti", d.Serial);
                if (null == device) {
                    // logger.Debug("Creating new Ubiquiti {0} ({1})", d.Model, d.Serial);
                    device = new DeviceModel();
                    device.Manufacturer = "Ubiquiti";
                    device.SerialNumber = d.Serial;
                // } else {
                //     logger.Debug("Updating Ubiquiti {0} ({1})", d.Model, d.Serial);
                }
                device.Name = d.Name;
                device.MacAddress = d.Mac;
                device.Ipv4Address = d.Ip;
                device.Model = d.Model;
                device.FirmwareVersion = d.FirmwareVersion;

                deviceRepo.Persist(device);
            }
        }
        #endregion

    }

}
