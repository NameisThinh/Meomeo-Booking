using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTDL.Startup))]
namespace HTDL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
