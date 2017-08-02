using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackEndBeezies.Web.Startup))]
namespace BackEndBeezies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
