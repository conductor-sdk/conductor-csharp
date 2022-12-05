using Microsoft.Extensions.Caching.Memory;
using System;
using Conductor.Api;
using RestSharp;

namespace Conductor.Client.Authentication
{
    public class OrkesApiClient
    {
        private const string AUTHORIZATION_HEADER = "X-Authorization";

        private static MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        private OrkesAuthenticationSettings _authenticationSettings = null;
        private Configuration _configuration = null;

        private TokenResourceApi _tokenClient = null;


        public OrkesApiClient(OrkesAuthenticationSettings authenticationSettings) : this(null, authenticationSettings) { }

        public OrkesApiClient(Configuration configuration, OrkesAuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
            _configuration = configuration;
            _tokenClient = new TokenResourceApi(_configuration);
            if (!String.IsNullOrEmpty(_authenticationSettings.KeyId) && !String.IsNullOrEmpty(_authenticationSettings.KeySecret)) {
                RefreshAuthenticationHeader();
            }
        }

        public T GetClient<T>() where T : IApiAccessor, new()
        {
            T client = new T();
            client.Configuration = _configuration;
            return client;
        }

        public void RefreshAuthenticationHeader()
        {
            _configuration.ApiKey[AUTHORIZATION_HEADER] = GetToken();
        }

        private string GetToken()
        {
            string token = (string)memoryCache.Get(_authenticationSettings);
            if (token != null)
            {
                return token;
            }
            return RefreshToken();
        }

        private string RefreshToken()
        {
            string token = GetTokenFromServer();
            System.DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(30);
            memoryCache.Set(_authenticationSettings, token, expirationTime);
            return token;
        }

        private string GetTokenFromServer()
        {
            return _tokenClient.GenerateToken
            (
                new Client.Models.GenerateTokenRequest
                (
                    keyId: _authenticationSettings.KeyId,
                    keySecret: _authenticationSettings.KeySecret
                )
            )._token;
        }
    }
}
