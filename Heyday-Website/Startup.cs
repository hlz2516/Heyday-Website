using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Heyday_Website.Models;
using Heyday_Website.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Heyday_Website
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(config =>
            {
                config.UseSqlServer(_configuration.GetConnectionString("AccountDB"));
                //config.UseInMemoryDatabase("memory");
            });

            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseSqlServer(_configuration.GetConnectionString("AppDB"));
                //config.UseInMemoryDatabase("AppDB");
            });

            services.AddIdentityCore<ApplicationUser>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
            }).AddRoles<IdentityRole>()
            .AddSignInManager()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(o => {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
            }).AddIdentityCookies(o => {
                o.ApplicationCookie.Configure(
                    config =>
                    {
                        config.LoginPath = "/Home/Index";
                        config.LogoutPath = "/Home/Index";
                        config.Cookie.Name = "Id";
                    });
            });

            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.IdleTimeout = new TimeSpan(TimeSpan.TicksPerMinute * 20);
            });

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            RootPathHelper.hostEnvironment = env;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
