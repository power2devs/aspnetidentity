using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demo03.Startup))]
namespace demo03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
