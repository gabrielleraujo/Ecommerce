using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ecommerce.Validation.Exceptions;

namespace Ecommerce.Ioc.Extensions
{
    public class ExceptionHandlerMidleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMidleware> _logger;

        public ExceptionHandlerMidleware(RequestDelegate next, ILogger<ExceptionHandlerMidleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestId = Guid.NewGuid();

            try
            {
                await _next(httpContext);
            }
            catch (ValidationException exception)
            {
                LogError(requestId, exception);
                await httpContext.ValidationExceptionHandleAsync(exception, requestId);
            }
            catch (ArgumentException exception)
            {
                LogError(requestId, exception);
                await httpContext.ArgumentExceptionHandleAsync(exception, requestId);
            }
            catch (Exception exception)
            {
                LogError(requestId, exception);
                await httpContext.ExceptionHandleAsync(exception, requestId);
            }
        }
        
        private void LogError(Guid requestId, Exception exception)
        {
            _logger.LogError($"API-ECOMMERCE: ErrorId: {requestId} - DateTime: {DateTime.Now} - {exception}");
        }
    }
}