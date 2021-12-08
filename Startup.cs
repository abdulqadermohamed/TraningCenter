using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TraningCenter.Startup))]
namespace TraningCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
