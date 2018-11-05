using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using KingPim.Repositories;
using KingPim.Repositories.Repositories;
using KingPim.Repositories.Interfaces;

namespace KingPim.Web
{
    public class Startup
    {
        // IConfiguration is what you use to get info from the appsettings.json file:
        IConfiguration _configuration;
        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuration for DB connection:
            var conn = _configuration.GetConnectionString("KingPim");

            // Service for the DB connection:
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conn));

            // Service for Identity:
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IIdentitySeed, IdentitySeed>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ISubCategory, SubCategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IAttributeGroup, AttributeGroupRepository>();
            services.AddTransient<IOneAttribute, OneAttributeRepository>();
            services.AddTransient<IHome, HomeRepository>();

            // Service for the password to make it easier to play with:
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            });

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx, IIdentitySeed identitySeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            // To get access to the wwwroot files:
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");


            });

            var runIdentitySeed = Task.Run(async () => await identitySeed.CreateAdminAccountIfEmpty()).Result;

            //Seed.FillIfEmpty(ctx);
        }
    }
}
