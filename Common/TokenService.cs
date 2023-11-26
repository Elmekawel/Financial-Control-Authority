using MICLifePortal.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace MICLifePortal.Common
{
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public string AccessToken { get; private set; }

        public TokenService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessToken()
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, Api.PathToken)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", Api.ClientId },
                    { "client_secret", Api.ClientSecret },
                    { "scope", Api.Scope },
                    { "grant_type", Api.GrantType }
                })
            };

            try
            {
                var tokenResponse = await client.SendAsync(tokenRequest);

                Console.WriteLine($"HTTP Status Code: {tokenResponse.StatusCode}");

                if (tokenResponse.IsSuccessStatusCode)
                {
                    var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
                    var tokenObject = JsonConvert.DeserializeObject<MICLifePortal.Models.TokenResponse>(tokenContent);

                    // Store the access token
                    AccessToken = tokenObject?.AccessToken;

                    return AccessToken;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request exception: {ex.Message}");
            }

            return null;
        }
    }
}
