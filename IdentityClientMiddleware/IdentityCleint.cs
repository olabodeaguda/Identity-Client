using IdentityClientMiddleware.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityClientMiddleware
{
    public static class IdentityCleint
    {
        public static IApplicationBuilder UseIdentityClient(
            this IApplicationBuilder app, IdentityClientModel identityClientModel)
        {
            return app.UseMiddleware(typeof(IdentityClientMiddleware), identityClientModel);
        }
    }
}
