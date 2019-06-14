using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AandA.Startup))]
namespace AandA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
