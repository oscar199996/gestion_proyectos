using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionTareas.Startup))]
namespace GestionTareas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
