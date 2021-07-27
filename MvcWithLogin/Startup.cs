using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWithLogin.Startup))]
namespace MvcWithLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
