using System.Threading.Tasks;
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
            services.AddTransient<IRoleSeed, RoleSeed>();
            // services.AddTransient<IUserRoleSeed, UserRoleSeed>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ISubCategory, SubCategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IAttributeGroup, AttributeGroupRepository>();
            services.AddTransient<IOneAttribute, OneAttributeRepository>();
            services.AddTransient<IHome, HomeRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings:
                options.Password.RequireDigit = false; // true
                options.Password.RequireLowercase = false; // 8
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false; // true
                options.Password.RequireLowercase = false;
                // options.Password.RequiredUniqueChars = 6;
                options.Password.RequiredLength = 3;

                // Lockout settings
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                // options.Lockout.MaxFailedAccessAttempts = 10;
                // options.Lockout.AllowedForNewUsers = true;

                // User settings
                // options.User.RequireUniqueEmail = true;
            });

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx, IIdentitySeed identitySeed, IRoleSeed roleSeed/*, IUserRoleSeed userRoleSeed*/)
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
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            var runIdentitySeed = Task.Run(async () => await identitySeed.CreateAdminAccountIfEmpty()).Result;
            var runRoleSeed = Task.Run(async () => await roleSeed.CreateRoleIfEmpty()).Result;
            // var runUserRoleSeed = Task.Run(async () => await userRoleSeed.CreateUserRoleIfEmpty()).Result;

            Seed.FillIfEmpty(ctx);
        }
    }
}
