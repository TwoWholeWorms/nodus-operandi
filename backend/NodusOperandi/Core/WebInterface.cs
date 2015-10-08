using Nancy.Hosting.Self;
using NLog;
using System;

namespace NodusOperandi.Core
{
    
    public class WebInterface
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();
        NancyHost host;
        
        public WebInterface()
        {

        }

        public void Run()
        {
            logger.Debug("Starting web interface");
            using (host = new NancyHost(new Uri(Configuration.NancyNamespace))) {
                host.Start();
            }
        }

    }

}

