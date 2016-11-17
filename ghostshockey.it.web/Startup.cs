using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ghostshockey.it.web.Startup))]
namespace ghostshockey.it.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
