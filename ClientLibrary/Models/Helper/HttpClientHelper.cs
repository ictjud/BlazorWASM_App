
namespace ClientLibrary.Models.Helper
{
    public class HttpClientHelper (IHttpClientFactory httpClientFactory, ITokenService tokenService) : IHttpClientHelper
    {
        public Task<HttpClient> GetPrivateHttpClientAsync()
        {
            throw new NotImplementedException();
        }

        public HttpClient GetPublicHttpClient()
        {
            throw new NotImplementedException();
        }
    }
}
