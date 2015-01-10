using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostCode.Startup))]
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
