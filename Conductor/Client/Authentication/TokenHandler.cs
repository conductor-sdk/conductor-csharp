using Conductor.Api;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Conductor.Client.Authentication
{
    public class TokenHandler
    {
        private static int REFRESH_TOKEN_RETRY_COUNTER_LIMIT = 5;
        private static readonly object _lockObject = new object();
        private readonly MemoryCache _memoryCache;

        public TokenHandler()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public string GetToken(OrkesAuthenticationSettings authenticationSettings, TokenResourceApi tokenClient)
        {
            string token = (string)_memoryCache.Get(authenticationSettings);
            if (token != null)
            {
                return token;
            }
            return RefreshToken(authenticationSettings, tokenClient);
        }

        private string RefreshToken(OrkesAuthenticationSettings authenticationSettings, TokenResourceApi tokenClient)
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
                catch (ApiException e)
                {
                    Console.WriteLine($"Failed to refresh authentication token, reason: {e}, request: {tokenRequest.ToJson()}");
                }
            }
            throw new Exception("Failed to refresh authentication token");
        }
    }
}