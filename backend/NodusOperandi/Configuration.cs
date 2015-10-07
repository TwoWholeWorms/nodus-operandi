/**
 * Based on Nancy.Demo.Samples.Configuration by Andreas Håkansson
 */

namespace NodusOperandi
{

    public class Configuration
    {
    
        static Configuration()
        {
            ConnectionString = @"mongodb://localhost:27017";
            EncryptionKey = "SuperSecretPass";
            HmacKey = "UberSuperSecret";
            Password = "Password1";
            DatabaseName = "NodusOperandi";
        }

        public static string ConnectionString { get; set; }

        public static string EncryptionKey { get; set; }

        public static string HmacKey { get; set; }

        public static string Password { get; set; }

        public static string DatabaseName { get; set; }

    }

}
