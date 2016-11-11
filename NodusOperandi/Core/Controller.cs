namespace NodusOperandi.Core
{

    using NLog;
    using System;
    using System.Threading;
    using Plugins.Core;

    public class Controller
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        public Controller()
        {
            // TODO: Unhorrible this
            PluginManager.AddPlugin(new DiscoverClientsPlugin());
        }

        public void Run()
        {
            var detectNewDevicesThread = new Thread (DoDetectNewDevices);
            detectNewDevicesThread.Start ();

            var heartbeatsThread = new Thread (DoHeartbeats);
            heartbeatsThread.Start ();

            // There must be a nicer way to do this? >.<
            while (true) {
                Thread.Sleep (60000);
            }
        }

        public static void DoDetectNewDevices()
        {
            if (null == PluginManager.DetectNewDevices) {
                logger.Info("No device detectors registered, ending detect devices thread.");
                return;
            }

            while (true) {
                // logger.Debug("Probing for new devices");
                foreach (PluginManager.DetectNewDevicesDelegate detectNewDevicesProcessor in PluginManager.DetectNewDevices.GetInvocationList()) {
                    try {
                        detectNewDevicesProcessor();
                    } catch (Exception e) {
                        logger.Error(e);
                    }
                }
                Thread.Sleep(10000);
            }
        }

        public static void DoHeartbeats()
        {
            if (null == PluginManager.ProcessHeartbeat) {
                logger.Info("No heartbeat processors registered, ending heartbeats thread.");
                return;
            }

            while (true) {
                // logger.Debug("Doing heartbeat");
                foreach (PluginManager.ProcessHeartbeatDelegate heartbeatProcessor in PluginManager.ProcessHeartbeat.GetInvocationList()) {
                    try {
                        heartbeatProcessor();
                    } catch (Exception e) {
                        logger.Error(e);
                    }
                }
                Thread.Sleep(10000);
            }
        }

    }

}
