using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropDownListCart.Startup))]
namespace DropDownListCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
