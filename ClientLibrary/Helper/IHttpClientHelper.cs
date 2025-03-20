namespace ClientLibrary.Helper
{
    public interface IHttpClientHelper
    {
        HttpClient GetPublicHttpClient();
        Task<HttpClient> GetPrivateHttpClientAsync();
    }
}
