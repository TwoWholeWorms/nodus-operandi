using System;

namespace NodusOperandi.Plugins.UbiquitiNetworkHardware
{

    public class Configuration
    {

        static Configuration()
        {
            UniFiMongoDbConnectionString = @"mongodb://127.0.0.1:27017";
            UniFiDatabaseName = "ace";
        }

        public static string UniFiMongoDbConnectionString { get; set; }
        public static string UniFiDatabaseName { get; set; }
    
    }

}
