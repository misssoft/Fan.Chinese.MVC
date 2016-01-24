using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace Fan.Chinese.MVC.Middleware
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;

        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("status code is " + httpContext.Response.StatusCode);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StatusCodeMiddlewareExtensions
    {
        public static IApplicationBuilder UseStatusCodeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatusCodeMiddleware>();
        }
    }
}
