using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityClientMiddleware.Filters
{
    public class IdentityAuthorizedAttribute : TypeFilterAttribute
    {
        public IdentityAuthorizedAttribute(string claimValue) : base(typeof(IdentityFilter))
        {
            Arguments = new object[] { new Claim(ClaimTypes.Role, claimValue) };
        }

        public IdentityAuthorizedAttribute() : base(typeof(IdentityFilter))
        {
            Arguments = new object[] {};
        }
    }
}
