using System;
using System.Diagnostics;
using System.Reflection;
using log4net;
using Orleans.Host.SiloHost;

namespace LocalSilo
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var logKey = "mfx-local-silo-" + Environment.MachineName;
            Log4stuff.Appender.Log4stuffAppender.AutoConfigureLogging(logKey);
            Process.Start("http://log4stuff.com/app/" + logKey);

            Log.Debug("Starting Orleans Silo");
            var siloHost = new OrleansSiloHost("testsilo")
            {
                ConfigFileName = "OrleansServerConfiguration.xml",
                Debug = true,
                FailOnMissingConfigFile = true,
                Verbose = 1
            };

            siloHost.InitializeOrleansSilo();

           // siloHost.LoadOrleansConfig();

            var ok = siloHost.StartOrleansSilo();
            Log.InfoFormat("Orleans silo started: {0}", ok);

            Console.WriteLine("Press almost any key to exit");
            Console.Read();
        }
    }
}
