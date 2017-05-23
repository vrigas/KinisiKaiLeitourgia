using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KinisiKaiLeitourgeia.Startup))]
namespace KinisiKaiLeitourgeia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
