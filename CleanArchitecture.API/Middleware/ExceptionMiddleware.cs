using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException re:
                        statusCode = (int) HttpStatusCode.NotFound;
                        break;
                    case ValidationException e:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonSerializer.Serialize(e.Errors);
                        result = JsonSerializer.Serialize(new ApiErrorException(statusCode, e.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonSerializer.Serialize(new ApiErrorException(statusCode, badRequestException.Message));
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonSerializer.Serialize(new ApiErrorException(statusCode, ex.Message, ex.StackTrace));
                }

                context.Response.StatusCode = statusCode;   

                await context.Response.WriteAsync(result);
            }
        }
    }
}
