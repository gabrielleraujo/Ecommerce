using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ecommerce.Ioc.Common;
using Ecommerce.Validation.Exceptions;

namespace Ecommerce.Ioc.Extensions
{
    public static class ExceptionHandler
    {
        public static Task ValidationExceptionHandleAsync(this HttpContext context, ValidationException exception, Guid requestId)
        {
            var message = CreateMessageError(context, exception);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(new ValidationErrorResponse(context.Response.StatusCode, exception, requestId, message).ToString());
        }

        public static Task ArgumentExceptionHandleAsync(this HttpContext context, ArgumentException exception, Guid requestId)
        {
            var message = CreateMessageError(context, exception);

            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            return context.Response.WriteAsync(new UnprocessableEntityErrorResponse(context.Response.StatusCode, requestId, message).ToString());
        }

        public static Task ExceptionHandleAsync(this HttpContext context, Exception exception, Guid requestId)
        {
            var message = CreateMessageError(context, exception);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new InternalServerErrorResponse(context.Response.StatusCode, requestId, message).ToString());
        }

        private static string CreateMessageError(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            return $"Erro no serviço: {context.Request.Path} - Mensagem: {exception.Message}";
        }
    }
}