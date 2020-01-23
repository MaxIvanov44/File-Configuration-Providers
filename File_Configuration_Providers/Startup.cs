using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace File_Configuration_Providers
{
    public class Startup
    {
        private IConfiguration AppConfiguration { get; set; }

        public Startup(IConfiguration config)
        {
            //var builder = new ConfigurationBuilder().AddJsonFile("conf.json");
            //var builder = new ConfigurationBuilder().AddXmlFile("config.xml");
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"name","TOM" },
                    { "age","35"}
                })
                .AddConfiguration(config);
            AppConfiguration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfiguration>(provider => AppConfiguration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var color = AppConfiguration["color"];
            ////var text = AppConfiguration["text:description:data"]; //для .xml
            //var text = AppConfiguration["firstname"];
            app.UseMiddleware<ConfigMiddleware>();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});
        }
    }
}