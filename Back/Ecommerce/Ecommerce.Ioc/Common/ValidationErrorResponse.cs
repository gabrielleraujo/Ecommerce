using Ecommerce.Validation.Exceptions;
using System;
using System.Collections.Generic;

namespace Ecommerce.Ioc.Common
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public IList<string> Details { get; set; }

        public ValidationErrorResponse(int statusCode, ValidationException exception, Guid requestId, string message)
        {
            StatusCode = statusCode;
            ErrorId = requestId;
            Error = "An error occourin in validation while processing your request.";
            Message = message;
            Details = exception.MessagesList;
        }
    }
}