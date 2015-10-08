namespace NodusOperandi.Core
{
    
    using Nancy;
    using Nancy.Hosting.Self;
    using NLog;
    using System;

    public class WebInterface
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();
        NancyHost host;
        
        public WebInterface()
        {

        }

        public void Run()
        {
            #if DEBUG
            logger.Debug("Enabling detailed Nancy error reporting");
            StaticConfiguration.DisableErrorTraces = false;
            #endif

            logger.Debug("Starting web interface");
            using (host = new NancyHost(new Uri(Configuration.NancyNamespace))) {
                host.Start();
                while (true) {
                    string line = Console.ReadLine();
                    logger.Debug("Command: " + line);
                }
            }
        }

    }

}

