using Ecommerce.Validation.Exceptions;

namespace Ecommerce.API.Commons.Responses
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public static ValidationErrorResponse From(ValidationException e)
        {
            return new ValidationErrorResponse
            {
                Code = e.HResult,
                Message = $"There were errors in Validation",
                Details = e.MessagesList
            };
        }
    }
}