using System;

namespace Ecommerce.Ioc.Common
{
    public class InternalServerErrorResponse : ErrorResponse
    {
        public InternalServerErrorResponse(int statusCode, Guid requestId, string message)
        {
            StatusCode = statusCode;
            ErrorId = requestId;
            Error = "An error occour while processing your request.";
            Message = message;
        }
    }
}