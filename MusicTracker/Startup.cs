using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicTracker.Startup))]
namespace MusicTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
