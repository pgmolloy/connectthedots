using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConnectTheDotsWebSite.Startup))]

namespace ConnectTheDotsWebSite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}