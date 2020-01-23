using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Configuration_Providers
{
    public class ConfigMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            AppConfiguration = config;
        }
        public IConfiguration AppConfiguration { get; set; }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"name: {AppConfiguration["name"]}  age: {AppConfiguration["age"]}");
        }
    }
}
