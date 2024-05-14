using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Conductor.Client.Authentication
{
    public class TokenHandler
    {
        private static int REFRESH_TOKEN_RETRY_COUNTER_LIMIT = 5;
        private static readonly object _lockObject = new object();
        private static readonly object _getTokenlockObject = new object();
        private readonly MemoryCache _memoryCache;
        private static ILogger _logger;

        public TokenHandler()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _logger = ApplicationLogging.CreateLogger<TokenHandler>();
        }
        public string GetToken(OrkesAuthenticationSettings authenticationSettings, TokenResourceApi tokenClient)
        {
            string token = (string)_memoryCache.Get(authenticationSettings);
            if (token != null)
            {
                return token;
            }

            lock (_getTokenlockObject)
            {
                token = (string)_memoryCache.Get(authenticationSettings);
                return token != null ? token : RefreshToken(authenticationSettings, tokenClient);
            }
        }

        public string RefreshToken(OrkesAuthenticationSettings authenticationSettings, TokenResourceApi tokenClient)
        {
            lock (_lockObject)
            {
                string token = GetTokenFromServer(authenticationSettings, tokenClient);
                var expirationTime = System.DateTimeOffset.Now.AddMinutes(30);
                _memoryCache.Set(authenticationSettings, token, expirationTime);
                return token;
            }
        }

        private string GetTokenFromServer(OrkesAuthenticationSettings authenticationSettings, TokenResourceApi tokenClient)
        {
            var tokenRequest = new Client.Models.GenerateTokenRequest(
                keyId: authenticationSettings.KeyId,
                keySecret: authenticationSettings.KeySecret
            );
            for (int attempt = 0; attempt < REFRESH_TOKEN_RETRY_COUNTER_LIMIT; attempt += 1)
            {
                try
                {
                    return tokenClient.GenerateToken(tokenRequest)._token;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Failed to refresh authentication token, attempt = {attempt}, error = {e.Message}");
                }
            }
            throw new Exception("Failed to refresh authentication token");
        }
    }
}