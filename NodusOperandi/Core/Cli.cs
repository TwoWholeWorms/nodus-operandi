namespace NodusOperandi.Core
{
    
    using NLog;
    using System;
    using System.Threading;
    using Plugins;
    
    public class Cli
    {

        readonly static Logger logger = LogManager.GetCurrentClassLogger();
        
        public Cli()
        {
            
        }

        public void Run()
        {
            //while (true) {
            //    string line = Console.ReadLine();
            //    // So, this is where the CLI command processor /will/ go
            //    logger.Debug("Command: " + line);
            //}
        }

    }

}
