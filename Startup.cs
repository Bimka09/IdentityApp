using IdentityApp.DB;
using IdentityApp.Services;
using IdentityApp.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityApp
{
    public class Startup(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionOptions = _configuration.GetRequiredSection(Connections.Section).Get<Connections>()!;
            var googleAuthOptions = _configuration.GetRequiredSection(GoogleAuthData.Section).Get<GoogleAuthData>()!;
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<ProductsDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionOptions.ProductsDB));
            services.AddDbContext<IdentityDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionOptions.IdentityDB, opts => opts.MigrationsAssembly("IdentityApp")));

            services.AddScoped<IEmailSender, ConsoleEmailSender>();

            services.AddDefaultIdentity<IdentityUser>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddAuthentication()
                 .AddGoogle(opts => {
                     opts.ClientId = googleAuthOptions.ClientId;
                     opts.ClientSecret = googleAuthOptions.ClientSecret;
                 });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
