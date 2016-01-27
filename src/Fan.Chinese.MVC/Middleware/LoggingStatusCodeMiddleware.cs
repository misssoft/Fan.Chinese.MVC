using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace Fan.Chinese.MVC.Middleware
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class LoggingStatusCodeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggingStatusCodeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingStatusCodeMiddleware>();
        }

        public Task Invoke(HttpContext httpContext)
        {
            var requestPath = httpContext.Request.Path.ToString();
            var responseStatusCode = httpContext.Response.StatusCode.ToString();
            var message = $"requesting {requestPath}, response code is {responseStatusCode}";
           _logger.LogInformation(message);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingStatusCodeMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingStatusCodeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingStatusCodeMiddleware>();
        }
    }
}
