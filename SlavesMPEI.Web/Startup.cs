using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlavesMPEI.Domain;
using SlavesMPEI.Domain.Entities;
using SlavesMPEI.Domain.Repositories.Abstracts;
using SlavesMPEI.Domain.Repositories.EF;
using SlavesMPEI.Infrastructure.ErrorDescribers;
using SlavesMPEI.Web.Services;

namespace SlavesMPEI.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            configuration.Bind("Project", new Config());        //����������� Project � appsettings.json � ������ Config.cs

            #region DataBase

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Config.ConnectionString, x => x.MigrationsAssembly("SlavesMPEI.Web")));

            #endregion DataBase

            #region DI

            services.AddTransient<IOrder, OrderRepository>();

            #endregion DI

            #region Identity

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()       //������ � AppDbContext
                .AddErrorDescriber<RussianIdentityErrorDescriber>() //�������� ��������� ������������!!!
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>      //������������ Identity
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.Configure<PasswordHasherOptions>(option => //������������ PasswordHasher
            {
                option.IterationCount = 12000;
            });

            services.ConfigureApplicationCookie(options =>      //������������ Cookie
            {
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/Denied");
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = System.TimeSpan.FromHours(24);
                options.SlidingExpiration = true;
                options.Cookie.Name = "ProfileCookie";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            #endregion Identity

            services.AddControllersWithViews()              //���������� MVC ��� RazorPages
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                    .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles(); //������������ ����������� �����
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}