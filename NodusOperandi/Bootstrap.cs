/**
 * Based on Nancy.Demo.Samples.Bootstrap by Andreas Håkansson
 */

namespace NodusOperandi
{

    using System.IO;
    using MongoDB.Driver;
    using Data;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Bootstrapper;
    using Nancy.Cryptography;
    using Nancy.Diagnostics;
    using Nancy.Extensions;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {

        public static MongoClient mongoClient;
        public static MongoDatabase mongoDb;

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var cryptographyConfiguration = new CryptographyConfiguration(
                new RijndaelEncryptionProvider(new PassphraseKeyGenerator(Configuration.EncryptionKey, new byte[] { 8, 2, 10, 4, 68, 120, 7, 14 })),
                new DefaultHmacProvider(new PassphraseKeyGenerator(Configuration.HmacKey, new byte[] { 1, 20, 73, 49, 25, 106, 78, 86 })));

            var authenticationConfiguration =
                new FormsAuthenticationConfiguration()
            {
                CryptographyConfiguration = cryptographyConfiguration,
                RedirectUrl = "/login",
                UserMapper = container.Resolve<IUserMapper>(),
            };

            FormsAuthentication.Enable(pipelines, authenticationConfiguration);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var config = new Configuration();

            var binDirectory = 
                Path.GetDirectoryName(this.GetType().GetAssemblyPath());

            var configPath =
                Path.Combine(binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load(configPath, config);

            var client =
                new MongoClient(Configuration.ConnectionString);
            mongoClient = client;

            container.Register((c, p) => client.GetServer());
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var server =
                container.Resolve<MongoServer>();

            container.Register((c, p) => server.GetDatabase(Configuration.DatabaseName));
            mongoDb = server.GetDatabase(Configuration.DatabaseName);

            container.Register<IAlertRepository, MongoDbAlertRepository>();
            container.Register<IClientRepository, MongoDbClientRepository>();
            container.Register<IDeviceRepository, MongoDbDeviceRepository>();
            container.Register<ISettingRepository, MongoDbSettingRepository>();
            container.Register<IStatisticsRepository, MongoDbStatisticsRepository>();

            container.Register<IAlertModelFactory, AlertModelFactory>();
            container.Register<IClientModelFactory, ClientModelFactory>();
            container.Register<IDeviceModelFactory, DeviceModelFactory>();
            container.Register<ISettingModelFactory, SettingModelFactory>();
            container.Register<IStatisticsModelFactory, StatisticsModelFactory>();
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration() { Password = Configuration.Password }; }
        }

    }

}
