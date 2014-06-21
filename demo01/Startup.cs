using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo01.Startup))]
namespace demo01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
