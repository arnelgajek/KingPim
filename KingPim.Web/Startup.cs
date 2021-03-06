﻿using System.Threading.Tasks;
using KingPim.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using KingPim.Repositories;
using KingPim.Repositories.Repositories;
using KingPim.Repositories.Interfaces;
using Newtonsoft.Json;
using KingPim.Models.Models;

namespace KingPim.Web
{
    public class Startup
    {
        // IConfiguration is what you use to get info from the appsettings.json file:
        IConfiguration _configuration;
        public Startup(IConfiguration conf, IHostingEnvironment env)
        {
            _configuration = conf;

            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();
            _configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);          

            // So the Json() in the controller will return correctly:
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            // Configuration for DB and SendGrid connection:
            var dbCon = _configuration["ConnectionStrings:KingPim"];
            var sendGridCon = _configuration["SendGridUserSecret:SendGridKey"];

            // Service for the DB connection:
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(dbCon));

            // Service for Identity:
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IIdentitySeed, IdentitySeed>();
            services.AddTransient<IRoleSeed, RoleSeed>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ISubCategory, SubCategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IAttributeGroup, AttributeGroupRepository>();
            services.AddTransient<IOneAttribute, OneAttributeRepository>();
            services.AddTransient<IProductOneAttributeValues, ProductOneAttributeValuesRepository>();
            services.AddTransient<IPredefinedAttrList, PredefinedAttrlistRepository>();
            services.AddTransient<IPredefinedAttributeListOptions, PredefinedAttributeListOptionsRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings:
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
            });

            services.AddMvc()
                    // To return data in XML.
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();
            services.AddMemoryCache();
            services.AddSession();               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx, IIdentitySeed identitySeed, IRoleSeed roleSeed)
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
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "details",
                    template: "{controller=Product}/{action=Details}/{id?}");
            });

            var runIdentitySeed = Task.Run(async () => await identitySeed.CreateAdminAccountIfEmpty()).Result;
            var runRoleSeed = Task.Run(async () => await roleSeed.CreateRoleIfEmpty()).Result;

            //Seed.FillIfEmpty(ctx);
        }
    }
}
