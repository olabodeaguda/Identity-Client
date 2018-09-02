using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityClientMiddleware.Models
{
    public class IdentityResponseModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public IdentityProfile data { get; set; }
    }
}
