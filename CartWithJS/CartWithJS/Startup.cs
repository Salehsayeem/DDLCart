using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CartWithJS.Startup))]
namespace CartWithJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
