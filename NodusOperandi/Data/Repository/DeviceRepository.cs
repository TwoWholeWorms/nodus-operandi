using Mono.Data.Sqlite;
using Newtonsoft.Json;
using NodusOperandi.Data.Models;
using NodusOperandi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using NLog;

namespace NodusOperandi.Data.Repository
{
    
    public class DeviceRepository
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger ();

        private SqliteContext db;
        
        public DeviceRepository (SqliteContext db)
        {

            this.db = db;

        }

        public Device [] GetAll ()
        {

            var output = new Device[0];

            using (var reader = db.ExecuteReader ("SELECT * FROM Device WHERE IsDeleted = 0")) {

                var data = new List<Device> ();
                while (reader.Read()) {

                    data.Add (hydrate (reader));

                }
                output = data.ToArray ();

            }

            return output;
            
        }

        public Device GetById (long id)
        {

            var cmd = db.Prepare ("SELECT * FROM Device WHERE Id = :id");
            cmd.Parameters.AddWithValue ("id", id);
            using (var reader = db.ExecuteReader(cmd)) {

                if (reader.Read ()) {

                    return hydrate (reader);

                }

            }

            return null;

        }

        private Device hydrate (SqliteDataReader reader)
        {

            var device = new Device ();

            device.Id = reader.GetInt64 (reader.GetOrdinal ("Id"));
            device.Name = reader.GetString (reader.GetOrdinal ("Name"));
            device.Icon = reader.GetString (reader.GetOrdinal ("Icon"));
            device.Manufacturer = reader.GetStringSafe (reader.GetOrdinal ("Manufacturer"));
            device.Model = reader.GetStringSafe (reader.GetOrdinal ("Model"));
            device.FirmwareVersion = reader.GetStringSafe (reader.GetOrdinal ("FirmwareVersion"));
            device.SerialNumber = reader.GetStringSafe (reader.GetOrdinal ("SerialNumber"));
            device.MacAddress = reader.GetStringSafe (reader.GetOrdinal ("MacAddress"));
            device.Ipv4Address = reader.GetStringSafe (reader.GetOrdinal ("Ipv4Address"));
            device.Ipv6Address = reader.GetStringSafe (reader.GetOrdinal ("Ipv6Address"));
            //device.LastSeenAt = reader.GetDateTime (reader.GetOrdinal ("LastSeenAt"));
            //device.UptimeStartedAt = reader.GetDateTime (reader.GetOrdinal ("UptimeStartedAt"));

            //IPStatus lastPingStatus;
            //Enum.TryParse<IPStatus>(reader.GetString (reader.GetOrdinal ("LastPingStatus")), out lastPingStatus);
            //device.LastPingStatus = lastPingStatus;

            //device.CreatedAt = reader.GetDateTime (reader.GetOrdinal ("CreatedAt"));
            //device.LastModifiedAt = reader.GetDateTime (reader.GetOrdinal ("LastModifiedAt"));
            device.IsActive = reader.GetBoolean (reader.GetOrdinal ("IsActive"));
            device.IsDeleted = reader.GetBoolean (reader.GetOrdinal ("IsDeleted"));

            device.PluginAssemblyName = reader.GetString (reader.GetOrdinal ("PluginAssemblyName"));
            device.PluginClass = reader.GetString (reader.GetOrdinal ("PluginClass"));
            device.PluginClassMethod = reader.GetString (reader.GetOrdinal ("PluginClassMethod"));

            var jsonData = reader.GetStringSafe (reader.GetOrdinal ("PluginControlData"));
            if (jsonData != null) {
                device.PluginControlData = JsonConvert.DeserializeObject<Dictionary<string, string>> (jsonData);
            } else {
                device.PluginControlData = new Dictionary<string, string> ();
            }

            device.ParentId = reader.GetInt64 (reader.GetOrdinal ("ParentId"));

            return device;
            
        }

    }

}
