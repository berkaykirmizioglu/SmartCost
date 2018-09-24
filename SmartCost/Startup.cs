using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartCost.Startup))]
namespace SmartCost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
