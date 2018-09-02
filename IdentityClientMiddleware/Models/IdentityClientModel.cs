using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityClientMiddleware.Models
{
    public class IdentityClientModel
    {
        public string RedisUrl { get; set; }
        public string IdentityServerUrl { get; set; }
    }
}
