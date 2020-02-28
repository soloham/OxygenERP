using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CERP.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<CERPWebModule>();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Account", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Account", "/Account/Logout");
                    options.Conventions.AuthorizeFolder("/Pages");
                    options.Conventions.AuthorizePage("/Index");

                    options.Conventions.AddAreaPageRoute("Account", "/Account/Login", "/Login");
                    options.Conventions.AddAreaPageRoute("Account", "/Account/Register", "/Register");
                    options.Conventions.AddAreaPageRoute("Account", "/Account/Lockout", "/Lockout");
                    options.Conventions.AddAreaPageRoute("Account", "/Account/AccessDenied", "/AccessDenied");
                    options.Conventions.AddAreaPageRoute("Account", "/Account/Logout", "/Logout");

                    options.Conventions.AddAreaPageRoute("FM", "/COA/List", "/COA");
                    options.Conventions.AddAreaPageRoute("FM", "/COA/Create", "/COA/Create");

                    options.Conventions.AddAreaPageRoute("Main", "/Dashboard", "/Dashboard");

                    //options.Conventions.AddPageRoute("/index", "{*url}");
                });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "cerpC";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100);

                options.AccessDeniedPath = "/AccessDenied";
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";

                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            //Register Syncfusion license here
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1OTQxQDMxMzcyZTM0MmUzMGZDUGl3WkUyOUpsdWhoZjdPK1hpNHVzY2FtMnZaT1FVa1EyL0lBR3RDUlE9");

            app.InitializeApplication();
        }
    }
}
