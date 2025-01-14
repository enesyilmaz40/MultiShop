using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using Duende.AccessTokenManagement;
using Microsoft.Extensions.Options;
using Duende.IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IMemoryCache memoryCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetTokenAsync()
        {
            if (_memoryCache.TryGetValue("multishoptoken", out string cachedToken))
            {
                return cachedToken;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            if (discoveryEndPoint.IsError)
            {
                throw new Exception("Discovery document request failed", discoveryEndPoint.Exception);
            }

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };


            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (tokenResponse.IsError)
            {
                throw new Exception("Token request failed", tokenResponse.Exception);
            }
            var expirationTime = tokenResponse.ExpiresIn > 0 ? DateTimeOffset.Now.AddSeconds(tokenResponse.ExpiresIn) : DateTimeOffset.Now.AddMinutes(5);
            _memoryCache.Set("multishoptoken", tokenResponse.AccessToken, expirationTime);

            return tokenResponse.AccessToken;
        }
    }
}
