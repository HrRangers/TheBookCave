using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using authentication_repo.Data;
using authentication_repo.Models;

namespace TheBookCave
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Added DBContext for authentication. AddIdenty, AddEntityFrameworkStores, AddDefaultTokenProviders.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
            });

            services.ConfigureApplicationCookie(options => {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromHours(3); 

            options.LoginPath = "/UserController/Login";
            options.LoginPath = "/UserController/AccessDenied";
            options.SlidingExpiration = true;

            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Book/Error");
            }

            app.UseStaticFiles();
            /// Baett vid
            app.UseAuthentication();
            /// Hér þarf að bæta við routes, fyrir aðra controllera.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Book",
                    template: "{controller=Book}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "User",
                    template: "{controller=User}/{action=UserLogin}/{id?}");
            });
        }
    }
}
