using Microsoft.Owin;
using Owin;
using PostCode;

[assembly: OwinStartup(typeof(Startup))]
namespace PostCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
