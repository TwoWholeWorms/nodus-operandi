namespace NodusOperandi.Plugins.UbiquitiUnifiHardware
{

    using NLog;
    using System.IO;
    using Nancy.Extensions;

    public class UbiquitiUnifiHardwarePlugin : AbstractPlugin
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        #region AbstractPlugin implementation
        static UbiquitiUnifiHardwarePlugin()
        {
            PluginManager.AddPlugin(new UbiquitiUnifiHardwarePlugin());
        }

        public UbiquitiUnifiHardwarePlugin()
        {
            var config = new Configuration();

            var binDirectory = Path.GetDirectoryName(GetType().GetAssemblyPath());
            var configPath = Path.Combine(binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load(configPath, config);
        }
        
        public override string Name {
            get {
                return "Ubiquiti Unifi Hardware Plugin";
            }
        }

        public override void RegisterPlugin()
        {
            PluginManager.ProcessHeartbeat += DoHeartbeat;
            PluginManager.DetectNewDevices += DetectNewDevices;
        }
        #endregion

        public void DoHeartbeat()
        {
            // …
        }

        public void DetectNewDevices()
        {
        }

    }

}
