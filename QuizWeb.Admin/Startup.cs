using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizWeb.Admin.Startup))]
namespace QuizWeb.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
