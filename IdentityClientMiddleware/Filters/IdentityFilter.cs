using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityClientMiddleware.Filters
{
    public class IdentityFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public IdentityFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("You have no access to this request. Thank you");
            }
        }
    }
}
