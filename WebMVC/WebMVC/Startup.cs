using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVC.Startup))]
namespace WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Data Source=DESKTOP-FZN\SQLEXPRESS;User Id=sa;Password=123456;Database=WebMVC_Hangfire;Pooling=true;");
        }
    }
}
