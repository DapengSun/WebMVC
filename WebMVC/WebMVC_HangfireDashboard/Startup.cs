using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(WebMVC_HangfireDashboard.Startup))]

namespace WebMVC_HangfireDashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Data Source=DESKTOP-FZN\SQLEXPRESS;User Id=sa;Password=123456;Database=WebMVC_Hangfire;Pooling=true;");

            app.UseHangfireDashboard();
        }
    }
}
