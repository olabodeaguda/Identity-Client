using IdentityClientMiddleware.Exceptions;
using IdentityClientMiddleware.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityClientMiddleware.Infrastruture
{
    public class IdentityServerCall
    {
        public async Task<IdentityResponseModel> ValidateToken(string token, string identityServerUrl)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync($"{identityServerUrl}/api/account/v1/profile");
                IdentityResponseModel responseBody = await response.Content.ReadAsAsync<IdentityResponseModel>();
                httpClient.Dispose();
                return responseBody;
            }
            catch (Exception)
            {
                httpClient.Dispose();
                throw new IdentityValidationException("An error occur while trying to validate identity");
            }

        }
    }
}
