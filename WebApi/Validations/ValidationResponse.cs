using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Validations
{
    public class ValidationResponse
    {
        public string ErrorCode { get; set; }
        public HttpStatusCode ErrorStatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorPropertyName { get; set; }

    }
}
