
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace TaskComputer.Middlewares
{
    public class GlobalExeptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExeptionHandlingMiddleware> _logger;

        public GlobalExeptionHandlingMiddleware(ILogger<GlobalExeptionHandlingMiddleware> logger) =>
            _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ProblemDetails problemDetails = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Server Error",
                    Type = "Server Error",
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };

                string json = JsonSerializer.Serialize(problemDetails);
                
                await context.Response.WriteAsync(json);
            }
        }
    }
}
