using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace File_Configuration_Providers
{
    public class Startup
    {
        private IConfiguration AppConfiguration { get; set; }

        public Startup()
        {
            //var builder = new ConfigurationBuilder().AddJsonFile("conf.json");
            //var builder = new ConfigurationBuilder().AddXmlFile("config.xml");
            var builder = new ConfigurationBuilder().AddIniFile("conf.ini");
            AppConfiguration = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var color = AppConfiguration["color"];
            //var text = AppConfiguration["text:description:data"]; //для .xml
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
    }
}