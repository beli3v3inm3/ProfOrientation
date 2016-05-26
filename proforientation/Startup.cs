using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(proforientation.Startup))]
namespace proforientation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
