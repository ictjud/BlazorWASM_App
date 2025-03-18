namespace ClientLibrary.Models.Helper
{
    public interface IHttpClientHelper
    {
        HttpClient GetPublicHttpClient();
        Task<HttpClient> GetPrivateHttpClientAsync();
    }
}
