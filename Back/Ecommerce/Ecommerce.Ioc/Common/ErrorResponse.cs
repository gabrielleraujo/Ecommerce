using Newtonsoft.Json;
using System;

namespace Ecommerce.Ioc.Common
{
    public abstract class ErrorResponse
    {
        public int StatusCode { get; set; }
        public Guid ErrorId { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}