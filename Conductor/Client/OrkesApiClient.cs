using Conductor.Api;
using Conductor.Client.Authentication;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using System;

namespace Conductor.Client
{
    public class OrkesApiClient
    {
        private Configuration _configuration;
        private MemoryCache _memoryCache;
        private TokenResourceApi _tokenClient;
        private OrkesAuthenticationSettings _authenticationSettings;

        public OrkesApiClient(Configuration configuration = null)
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _tokenClient = null;
            _authenticationSettings = null;
            _configuration = configuration;
            if (_configuration != null && !string.IsNullOrEmpty(_configuration.keyId) && !string.IsNullOrEmpty(_configuration.keySecret))
            {
                _authenticationSettings = new OrkesAuthenticationSettings(_configuration.keyId, _configuration.keySecret);
                RefreshAuthenticationHeader();
            }
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
            try
            {
                _configuration.AccessToken = GetToken();
            }
            catch (ApiException)
            {
                // TODO
            }
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
