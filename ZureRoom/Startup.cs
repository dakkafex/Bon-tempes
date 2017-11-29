using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZureRoom.Startup))]
namespace ZureRoom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
