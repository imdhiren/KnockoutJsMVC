using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockoutJsMVC.Startup))]
namespace KnockoutJsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
