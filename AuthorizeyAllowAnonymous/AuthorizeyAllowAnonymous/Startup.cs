using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorizeyAllowAnonymous.Startup))]
namespace AuthorizeyAllowAnonymous
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
