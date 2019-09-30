using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardSeek.Startup))]
namespace BoardSeek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
