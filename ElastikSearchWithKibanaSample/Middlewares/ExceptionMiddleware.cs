using System.Net;
using System.Text.Json;
using ElastikSearchWithKibanaSample.Wrapper;
using Microsoft.AspNetCore.Http;

namespace ElastikSearchWithKibanaSample.Middlewares
{

    public static class ExceptionMiddlewareExtention
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                await HandleExceptionAsync(httpContext, exception);

            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>(exception.Message, false);
            switch (exception)
            {
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ArgumentNullException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}
