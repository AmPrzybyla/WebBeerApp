using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBeerApp.Startup))]
namespace WebBeerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
