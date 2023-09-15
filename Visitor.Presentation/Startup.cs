using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Visitor.Presentation.Startup))]
namespace Visitor.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
