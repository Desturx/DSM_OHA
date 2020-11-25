using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBookReViewDSM.Startup))]
namespace WebBookReViewDSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
