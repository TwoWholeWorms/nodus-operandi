using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NodusOperandi.Core;
using NodusOperandi.Plugins;
using NodusOperandi.Utilities;

namespace NodusOperandi
{

    public static class NodusOperandi
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        static List<NodusOperandiPlugin> Plugins = new List<NodusOperandiPlugin>();
        static List<Thread>              Threads = new List<Thread>();

        public static void Main(string[] args)
        {
            try {
                logger.Info("NodusOperandi v{0}", CoreAssembly.Version);
                logger.Info("==============={0}\n", new String('=', CoreAssembly.Version.ToString().Length));

                Initialise();
                Run();

                logger.Info("All connections closed, threads finished. BAIBAI! :D");
            } catch (Exception e) {
                logger.Fatal(e);
            }
        }

        public static void Initialise()
        {
            InitialisePlugins();
        }

        public static void InitialisePlugins()
        {
            logger.Info("Initialising plugins");
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            // Add the plugin initialiser
            AppDomain.CurrentDomain.AssemblyLoad += PluginInitializer;

            foreach (string dll in Directory.GetFiles(pluginsPath, "*.dll", SearchOption.TopDirectoryOnly)) {
                try {
                    Assembly loadedAssembly = Assembly.LoadFile(dll);
                    logger.Trace("Loaded plugin `{0}`", loadedAssembly.GetName());
                } catch (FileLoadException e) {
                    logger.Trace("Plugin file `{0}` has already been loaded? O.o", dll);
                    logger.Trace(e);
                } catch (BadImageFormatException e) {
                    logger.Trace("`{0}` is not a valid Lumbricus plugin file.", dll);
                    throw e;
                }
            }

            // Remove the plugin initialiser as it's no longer needed
            AppDomain.CurrentDomain.AssemblyLoad -= PluginInitializer;

            logger.Info("{0} plugins enabled", Plugins.Count);
        }

        static void PluginInitializer(object sender, AssemblyLoadEventArgs args)
        {
            logger.Trace("{0} loaded plugin assembly {1}", sender.ToString(), args.LoadedAssembly.GetName());
            // Call the static constructors on each plugin class
            foreach (NodusOperandiPlugin attr in args.LoadedAssembly.GetCustomAttributes(typeof(NodusOperandiPlugin), false)) {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(attr.Type.TypeHandle);
            }
        }

        public static void Run()
        {
            logger.Debug("Launching controller");

            var controllerThread = new Thread(RunController);
            controllerThread.Start();
            Threads.Add(controllerThread);

            logger.Debug("Launching web interface");

            var webThread = new Thread(RunWebInterface);
            webThread.Start();
            Threads.Add(webThread);

            while (Threads.Count > 0) {
                foreach (Thread thread in Threads) {
                    if (!thread.IsAlive) {
                        Threads.Remove(thread);
                        break;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public static void RunController()
        {
            try {
                var controller = new Controller();
                controller.Run();
            } catch (Exception e) {
                logger.Error(e);
            }
        }

        public static void RunWebInterface()
        {
            try {
                var webInterface = new WebInterface();
                webInterface.Run();
            } catch (Exception e) {
                logger.Error(e);
            }
        }

    }

}
