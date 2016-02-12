using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(H8QMedia.Web.Startup))]

namespace H8QMedia.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
