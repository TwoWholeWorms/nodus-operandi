namespace NodusOperandi
{

    using NLog;
    using System.Configuration;
    using System.Collections.Generic;
    using Plugins;
    
    public static class PluginManager
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        public static List<AbstractPlugin> Plugins = new List<AbstractPlugin>();

        public delegate void ProcessHeartbeatDelegate();
        public static ProcessHeartbeatDelegate ProcessHeartbeat;

        public delegate void DetectNewDevicesDelegate();
        public static DetectNewDevicesDelegate DetectNewDevices;

        static PluginManager()
        {
            // …
        }
        
        public static void AddPlugin(AbstractPlugin plugin)
        {
            logger.Debug("Registering plugin {0}", plugin.Name);
            plugin.RegisterPlugin();

            Plugins.Add(plugin);
        }

    }

}
