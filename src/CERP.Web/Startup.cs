using Autofac.Core;
using CERP.Web.BusinessLogic.Core.Services.ApprovalRouteService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;

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
                    options.Conventions.AuthorizeAreaFolder("Account", "/Pages/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Account", "/Pages/Account/Logout");
                    options.Conventions.AuthorizeAreaFolder("FM", "/");
                    options.Conventions.AuthorizeAreaFolder("HR", "/");
                    options.Conventions.AuthorizeAreaFolder("Main", "/");
                    options.Conventions.AuthorizeAreaFolder("Payroll", "/");
                    options.Conventions.AuthorizeAreaFolder("Setup", "/");
                    options.Conventions.AuthorizePage("/Index");

                    options.Conventions.AddPageRoute("/Account/Login", "/Login");
                    options.Conventions.AddPageRoute("/Account/Register", "/Login");
                    options.Conventions.AddPageRoute("/Account/Lockout", "/Lockout");
                    options.Conventions.AddPageRoute("/Account/AccessDenied", "/AccessDenied");
                    options.Conventions.AddPageRoute("/Account/Logout", "/Logout");

                    options.Conventions.AddAreaPageRoute("FM", "/COA/List", "/COA");
                    options.Conventions.AddAreaPageRoute("FM", "/COA/Create", "/COA/Create");
                    options.Conventions.AddAreaPageRoute("FM", "/COA/Edit", "/COA/Edit");

                    options.Conventions.AddAreaPageRoute("FM", "/COA/Categories", "/COA/Categories");
                    options.Conventions.AddAreaPageRoute("FM", "/COA/Categories/CreateCategory", "/COA/Category/Create");

                    options.Conventions.AddAreaPageRoute("Main", "/Dashboard", "/Dashboard");

                    //options.Conventions.AddPageRoute("/index", "{*url}");
                })                                            
                .AddNewtonsoftJson(options =>
                {
                    //options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "oxyC";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                //options.AccessDeniedPath = "/AccessDenied";
                //options.LoginPath = "/Login";
                //options.LogoutPath = "/Logout";

                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;

            });

            services.AddSingleton<IApprovalRoutesManager, ApprovalRoutesManager>();
        }

        public void Configure(IApplicationBuilder app)
        {
            //Register Syncfusion license here
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1OTQxQDMxMzcyZTM0MmUzMGZDUGl3WkUyOUpsdWhoZjdPK1hpNHVzY2FtMnZaT1FVa1EyL0lBR3RDUlE9");

            app.InitializeApplication();
        }
    }
}
