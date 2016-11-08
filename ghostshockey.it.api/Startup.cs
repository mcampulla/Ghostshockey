using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ghostshockey.it.api.Startup))]

namespace ghostshockey.it.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}