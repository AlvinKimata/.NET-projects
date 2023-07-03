using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WingTipToys.Startup))]
namespace WingTipToys
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
