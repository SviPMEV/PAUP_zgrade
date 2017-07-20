using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAUP_zgrade.Startup))]
namespace PAUP_zgrade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
