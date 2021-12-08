using System;
using System.Collections.Generic;

namespace Ecommerce.Validation.Exceptions
{
    public class ValidationException : Exception
    {
        public readonly IList<string> MessagesList;

        public ValidationException(IList<string> messages)
        {
            MessagesList = messages;
        }
    }
}