using System;

namespace Ecommerce.Ioc.Common
{
    public class UnprocessableEntityErrorResponse : ErrorResponse
    {
        public UnprocessableEntityErrorResponse(int statusCode, Guid requestId, string message)
        {
            StatusCode = statusCode;
            ErrorId = requestId;
            Error = "The server understands the content type of the request entity, and the request syntax is correct, but it was not possible to process the present instructions.";
            Message = message;
        }
    }
}