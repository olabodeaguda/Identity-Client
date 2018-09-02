using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityClientMiddleware.Models
{
    public class IdentityProfile
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string lastName { get; set; }
        public string otherNames { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
