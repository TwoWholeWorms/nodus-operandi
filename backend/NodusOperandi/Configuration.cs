/**
 * Based on Nancy.Demo.Samples.Configuration by Andreas Håkansson
 */

namespace NodusOperandi
{

    public class Configuration
    {
    
        static Configuration()
        {
            ConnectionString = @"mongodb://127.0.0.1:27017";
            EncryptionKey = "SuperSecretPass";
            HmacKey = "UberSuperSecret";
            Password = "Password1";
            DatabaseName = "NodusOperandi";
            NancyNamespace = "http://127.0.0.1:6737";
        }

        public static string ConnectionString { get; set; }

        public static string EncryptionKey { get; set; }

        public static string HmacKey { get; set; }

        public static string Password { get; set; }

        public static string DatabaseName { get; set; }

        public static string NancyNamespace { get; set; }

    }

}
