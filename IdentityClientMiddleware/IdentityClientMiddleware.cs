using IdentityClientMiddleware.Infrastruture;
using IdentityClientMiddleware.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityClientMiddleware
{
    public class IdentityClientMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IdentityClientModel identityClientModel;
        public IdentityClientMiddleware(RequestDelegate _next,
            IdentityClientModel _identityClientModel)
        {
            next = _next;
            identityClientModel = _identityClientModel;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Replace("Bearer", "");
                token = token.Replace("bearer", "");
                token = token.Trim();
                IdentityServerCall identityServerCall = new IdentityServerCall();
                IdentityResponseModel responseBody = await identityServerCall.ValidateToken(token, identityClientModel.IdentityServerUrl);
                context.Response.ContentType = "application/json";
                if (responseBody.code != "IDS00")
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody,
                        new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }));
                }
                else
                {
                    IdentityProfile identityProfile = responseBody.data;// JsonConvert.DeserializeObject<IdentityProfile>(responseBody.data);
                    List<ClaimsIdentity> claims = new List<ClaimsIdentity>()
                    {
                        new ClaimsIdentity(new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, identityProfile.Id),
                            new Claim(ClaimTypes.Authentication, "true"),
                            new Claim(ClaimTypes.Email, string.IsNullOrEmpty(identityProfile.email)?string.Empty:identityProfile.email),
                            new Claim(ClaimTypes.MobilePhone,string.IsNullOrEmpty(identityProfile.phoneNumber)? string.Empty: identityProfile.phoneNumber),
                            new Claim(ClaimTypes.Name, $"{identityProfile.lastName} {identityProfile.otherNames??string.Empty}"),
                            new Claim(ClaimTypes.Surname, identityProfile.lastName)
                        },"Basic")
                    };

                    context.User = new ClaimsPrincipal(claims);
                    await next(context);
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
