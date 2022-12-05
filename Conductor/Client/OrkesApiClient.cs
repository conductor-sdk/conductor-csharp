using Conductor.Api;
using Conductor.Client.Authentication;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using System;

namespace Conductor.Client
{
    public class OrkesApiClient
    {
        private const string AUTHORIZATION_HEADER = "X-Authorization";

        private Configuration _configuration;
        private MemoryCache _memoryCache;

        private OrkesAuthenticationSettings _authenticationSettings;
        private TokenResourceApi _tokenClient;

        private OrkesApiClient()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _configuration = null;
            _authenticationSettings = null;
            _tokenClient = null;
        }

        public OrkesApiClient(Configuration configuration = null, OrkesAuthenticationSettings authenticationSettings = null) : this()
        {
            _authenticationSettings = authenticationSettings;
            _configuration = configuration;
            RefreshAuthenticationHeader();
        }

        public T GetClient<T>() where T : IApiAccessor, new()
        {
            T client = new T();
            if (_configuration != null)
            {
                client.Configuration = _configuration;
            }
            return client;
        }

        private void RefreshAuthenticationHeader()
        {
            if (_authenticationSettings == null)
            {
                return;
            }
            _configuration.ApiKey[AUTHORIZATION_HEADER] = GetToken();
        }

        private string GetToken()
        {
            string token = (string)_memoryCache.Get(_authenticationSettings);
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
            _memoryCache.Set(_authenticationSettings, token, expirationTime);
            return token;
        }

        private string GetTokenFromServer()
        {
            if (_tokenClient == null)
            {
                _tokenClient = GetClient<TokenResourceApi>();
            }
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
