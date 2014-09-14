using System;
using System.Web.Http;

namespace OrleansFrontEnd.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return string.Format("hello @ {0}", DateTime.Now);
        }
    }
}
