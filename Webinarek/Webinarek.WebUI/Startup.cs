using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webinarek.Startup))]
namespace Webinarek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
