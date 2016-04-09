using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace tobiaslundin.se
{
    public class Startup
    {
        private IConfiguration config { get; set; }
        private System.DateTime StartTime = System.DateTime.UtcNow;

        public Startup(IHostingEnvironment env) {

            var builder = new ConfigurationBuilder()
                            .AddJsonFile("config.json")
                            .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
                            
            config = builder.Build();
            config["envName"] = env.EnvironmentName;
        }

        private void AddEnvironmentVariables()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application,
        // visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add config to services
            services.AddSingleton(provider => config);

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(minLevel:LogLevel.Verbose);

            app.UseDeveloperExceptionPage();
            // env.IsDevelopment() ? app.UseExceptionHandler("/Home/Error");

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            loggerFactory.CreateLogger("Startup")
                         .LogInformation("STARTUP TIME {0} MS", (System.DateTime.UtcNow - StartTime).TotalMilliseconds);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
