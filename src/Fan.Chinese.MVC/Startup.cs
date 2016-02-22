using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fan.Chinese.MVC.Middleware;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Fan.Chinese.MVC.Models;
using Fan.Chinese.MVC.Repository;
using Fan.Chinese.MVC.Services;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Server.Kestrel.Http;
using Microsoft.AspNet.StaticFiles;

namespace Fan.Chinese.MVC
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IVocabularyRepository, VocabularyRepository>();
        }

        
        public void ConfigurePrototype(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWelcomePage("/welcome");
            
            app.UseDeveloperExceptionPage();
            
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(@"E:\GitHub\Fan.Chinese.MVC\src\Fan.Chinese.MVC\Properties"),
                RequestPath = new PathString("/Properties")
            });

            app.UseStaticFiles();

            app.UseStatusCodePagesWithRedirects("/NotFoundPage.html");

            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("throw")) throw new Exception("Exception triggered!");
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync($"<html><body><h2>Nihao {env.EnvironmentName}!</h2>");
                await context.Response.WriteAsync("<ul>");
                await context.Response.WriteAsync("<li><a href=\"/welcome\">Welcome Page</a></li>");
                await context.Response.WriteAsync("<li><a href=\"/Properties\">Browse Property Directory</a></li>");
                await context.Response.WriteAsync("<li><a href=\"/?throw=true\">Throw Exception</a></li>");
                await context.Response.WriteAsync("</ul>");
                await context.Response.WriteAsync("</body></html>");
            });

        }

        public void ConfigureDevelopment(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Information);

            app.UseLoggingStatusCodeMiddleware();

            app.UseDeveloperExceptionPage();

            Configure(app);
        }

        
        public void ConfigureProduction(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Warning);

            app.UseExceptionHandler("/Error/System");

            Configure(app);
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseStatusCodePages();  //Default 404 page by MS
            app.UseStatusCodePagesWithRedirects("~/NotFound.html");  //WWW route error page
            //app.UseStatusCodePagesWithRedirects("/Home/NotFoundPage"); //MVC error Page


            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute( name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });


            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                     .Database.Migrate();
            }

            SampleData.Initialize(app.ApplicationServices);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
