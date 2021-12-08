using System.Collections.Generic;

namespace Ecommerce.API.Commons.Responses
{
    public abstract class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IList<string> Details { get; set; }
    }
}