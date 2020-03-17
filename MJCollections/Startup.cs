using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MJCollections.Startup))]
namespace MJCollections
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
