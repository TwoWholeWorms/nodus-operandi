namespace NodusOperandi.Plugins.UbiquitiMfiHardware
{

    using NLog;
    using System.IO;
    using Nancy.Extensions;

    public class UbiquitiMfiHardwarePlugin : AbstractPlugin
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        #region AbstractPlugin implementation
        static UbiquitiMfiHardwarePlugin()
        {
            PluginManager.AddPlugin(new UbiquitiMfiHardwarePlugin());
        }

        public UbiquitiMfiHardwarePlugin()
        {
            var config = new Configuration();

            var binDirectory = Path.GetDirectoryName(GetType().GetAssemblyPath());
            var configPath = Path.Combine(binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load(configPath, config);
        }
        
        public override string Name {
            get {
                return "Ubiquiti mFi Hardware Plugin";
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
