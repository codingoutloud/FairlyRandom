using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FairlyRandom.Startup))]
namespace FairlyRandom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
