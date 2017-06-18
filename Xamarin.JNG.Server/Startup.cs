using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Xamarin.JNG.Server.Startup))]

namespace Xamarin.JNG.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}