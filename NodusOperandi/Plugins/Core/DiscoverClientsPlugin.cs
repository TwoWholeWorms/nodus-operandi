using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NodusOperandi.Plugins.Core
{

    using NLog;
    using System.IO;
    using Nancy.Extensions;
    using Data.Models;

    public class DiscoverClientsPlugin : AbstractPlugin
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();

        #region AbstractPlugin implementation
        static DiscoverClientsPlugin()
        {
            
            // PluginManager.AddPlugin(new DiscoverClientsPlugin());

        }

        public DiscoverClientsPlugin()
        {
            
            var config = new Configuration();

            var binDirectory = Path.GetDirectoryName(this.GetType().GetAssemblyPath());
            var configPath = Path.Combine(binDirectory ?? @".\", "deploy.config");

            ConfigurationLoader.Load(configPath, config);

        }

        public override string Name {
            
            get {
                return "Discover Clients Plugin";
            }

        }

        public override void RegisterPlugin()
        {
            
            PluginManager.ProcessHeartbeat += DoHeartbeat;

        }
        #endregion

        public void DoHeartbeat()
        {
            
            return;

            // TODO: Figure out how to do this within .NET itself, rather than spawning a process to do it
            var process = new Process();
            var info = new ProcessStartInfo();
            info.FileName = "arp";
            info.Arguments = "-a";
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            process.StartInfo = info;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            // logger.Debug(output);

            Regex regex = new Regex("[\r\n]+");
            string[] lines = regex.Split(output);

            regex = new Regex(@"^([^ ]+) \(([^\)]+)\) at ([a-zA-Z0-9:]+) on ([^ ]+).*$");
            foreach (string line in lines) {
                Match result = regex.Match(line);
                if (result.Success) {
                    if (result.Groups[3].ToString().ToLower() != "ff:ff:ff:ff:ff:ff") {
                        string hostname = result.Groups[1].ToString();
                        string ipv4Address = result.Groups[2].ToString();
                        string macAddress = result.Groups[3].ToString();

                        //ClientModel client = clientRepo.GetByMacAddress(macAddress);
                        //if (null == client) {
                        //    client = new ClientModel();
                        //    client.MacAddress = macAddress;
                        //}
                        //client.Ipv4Address = ipv4Address;
                        //client.Hostname = hostname;
                        //client.LastModifiedAt = DateTime.Now;
                        //Ping ping = new Ping();
                        //PingReply reply = ping.Send(ipv4Address);
                        //if (reply.Status == IPStatus.Success) {
                        //    if (null == client.UptimeStartedAt) {
                        //        client.UptimeStartedAt = DateTime.Now;
                        //    }
                        //    client.LastSeenAt = DateTime.Now;
                        //} else if (null != client.UptimeStartedAt && DateTime.Now.Subtract(client.LastSeenAt).TotalSeconds > 600) {
                        //    client.UptimeStartedAt = null;
                        //}
                        //client.LastPingStatus = reply.Status;

                        //clientRepo.Persist(client);
                        //logger.Debug("{0} {1}", result.Groups[3], result.Groups[2], result.Groups[1]);
                    }
                }
            }

        }

    }

}
