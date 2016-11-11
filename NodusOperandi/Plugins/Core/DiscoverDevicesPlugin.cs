using System;
using System.Net.NetworkInformation;

namespace NodusOperandi.Plugins.Core
{

    using NLog;
    using System.IO;
    using Nancy.Extensions;
    using System.Threading;
    using System.Text;

    public class DiscoverDevicesPlugin : AbstractPlugin
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger ();

        #region AbstractPlugin implementation
        static DiscoverDevicesPlugin ()
        {
            // PluginManager.AddPlugin(new DiscoverDevicesPlugin());
        }

        public DiscoverDevicesPlugin ()
        {
            var config = new Configuration ();

            var binDirectory = Path.GetDirectoryName (this.GetType ().GetAssemblyPath ());
            var configPath = Path.Combine (binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load (configPath, config);
        }

        public override string Name {
            get {
                return "Discover Devices Plugin";
            }
        }

        public override void RegisterPlugin ()
        {
            PluginManager.ProcessHeartbeat += DoHeartbeat;
            PluginManager.DetectNewDevices += DoDetectNewDevices;
        }
        #endregion

        public void DoHeartbeat ()
        {
            return;
        }

        public void DoDetectNewDevices ()
        {
            
        }

        private void SendAsyncPing (string ipAddress)
        {
            
            try {
                int timeout = 5000;
                AutoResetEvent are = new AutoResetEvent (false);
                Ping ping = new Ping ();
                ping.PingCompleted += PingCompletedHandler;
                string data = "Discovering network devices";
                byte [] byteBuffer = Encoding.ASCII.GetBytes (data);
                PingOptions pingOptions = new PingOptions (64, true);
                ping.SendAsync (ipAddress, timeout, byteBuffer, pingOptions, are);
                are.WaitOne ();
                // Handle ping response here
            } catch (PingException e) {
                // Invalid IP address encountered
            } catch (Exception e) {
                // An error occurred
            }

        }

        static void PingCompletedHandler (object sender, PingCompletedEventArgs e)
        {
            
            try {
                if (e.Cancelled) {
                    Console.WriteLine ("Ping cancelled.");

                    // Let the main thread resume. 
                    // UserToken is the AutoResetEvent object that the main thread 
                    // is waiting for.
                    ((AutoResetEvent)e.UserState).Set ();
                }

                // If an error occurred, display the exception to the user.
                if (e.Error != null) {
                    Console.WriteLine ("Ping failed>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
                    //this will print exception
                    //Console.WriteLine (e.Error.ToString ());

                    // Let the main thread resume. 
                    ((AutoResetEvent)e.UserState).Set ();
                }

                PingReply reply = e.Reply;

                // Let the main thread resume.
                ((AutoResetEvent)e.UserState).Set ();
            } catch (PingException pe) {
                Console.WriteLine ("INVALID IP ADDRESS");
            } catch (Exception ex) {
                Console.WriteLine ("Exception " + ex.Message);
            }

        }

    }

}
