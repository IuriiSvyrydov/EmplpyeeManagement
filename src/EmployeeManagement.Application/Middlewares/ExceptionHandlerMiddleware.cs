using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace EmployeeManagement.Application.Middlewares;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.InternalServerError, "Internal Server Error.");
            }
        }
      
        private  async Task HandleExceptionAsync(HttpContext context, string exceptionMessage,
        HttpStatusCode httpStatusCode,
         string message)
        {
            _logger.LogError(exceptionMessage);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            string result = JsonSerializer.Serialize(message);
            await context.Response.WriteAsync(result);
        }
    }
