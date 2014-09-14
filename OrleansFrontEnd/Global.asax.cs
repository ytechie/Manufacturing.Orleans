using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using GrainInterfaces;
using log4net;

namespace OrleansFrontEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Connect to our orleans cluster
            Log.Debug("Initializing orleans client");
            try
            {
                Orleans.OrleansClient.Initialize(System.AppDomain.CurrentDomain.BaseDirectory +
                                                 "OrleansClientConfiguration.xml");
            }
            catch (AggregateException ae)
            {
                //In development, the client could try to connect before the silo is started. This
                //is designed to handle that by waiting and retrying
                if (ae.InnerException.InnerException.InnerException.Message == "Target silo is unavailable")
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    Orleans.OrleansClient.Initialize(AppDomain.CurrentDomain.BaseDirectory +
                                                 "OrleansClientConfiguration.xml");
                }
            }
            Log.Info("Orleans client initialized");
        }
    }
}
