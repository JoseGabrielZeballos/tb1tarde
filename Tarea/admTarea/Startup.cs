using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admTarea.Startup))]
namespace admTarea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
