using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSheets.Startup))]
namespace BSheets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
