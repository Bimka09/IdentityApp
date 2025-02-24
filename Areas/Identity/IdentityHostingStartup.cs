using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(IdentityApp.Areas.Identity.IdentityHostingStartup))]

namespace IdentityApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}