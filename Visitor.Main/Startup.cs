using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Visitor.Main.Startup))]
namespace Visitor.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
