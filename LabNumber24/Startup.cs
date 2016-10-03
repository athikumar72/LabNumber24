using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabNumber24.Startup))]
namespace LabNumber24
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
