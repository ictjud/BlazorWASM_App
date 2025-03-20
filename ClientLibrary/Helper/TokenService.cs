﻿using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

namespace ClientLibrary.Helper
{
    public class TokenService(IBrowserCookieStorageService cookieStorageService) : ITokenService
    {
        public string FormToken(string jwt, string refresh)
        {
            return $"{jwt}--{refresh}";
        }

        public async Task<string> GetJWTTokenAsync(string key)
        {
            return await GetTokenAsync(key, 0);
        }

        private async Task<string> GetTokenAsync(string key, int position)
        {
            try
            {
                string token = await cookieStorageService.GetAsync(key);
                return token != null ? token.Split("--")[position] : null!;
            }
            catch
            {
                return null!;
            }

        }

        public async Task<string> GetRefreshTokenAsync(string key)
        {
            return await GetTokenAsync(key, 1);
        }

        public async Task RemoveCookie(string key)
        {
            await cookieStorageService.RemoveAsync(key);
        }

        public async Task SetCookie(string key, string value, int days, string path)
        {
            await cookieStorageService.SetAsync(key, value, days, path);
        }
    }
}