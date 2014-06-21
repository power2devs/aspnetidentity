using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo02.Startup))]
namespace demo02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
