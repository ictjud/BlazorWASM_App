using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Authentication;
using System.Web;

namespace ClientLibrary.Services
{
    public class AuthenticationService(IApiCallHelper apiCallHelper, IHttpClientHelper httpClientHelper) : IAuthenticationService
    {
        // Method to create a new user
        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {
            // Get a private HttpClient instance for making authenticated API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object to encapsulate the details of the API request
            var apiCall = new ApiCall
            {
                Route = Constant.Authentication.Register, // API endpoint for user registration
                Client = client, // HttpClient instance
                Type = Constant.ApiCallType.Post, // HTTP method type
                Id = null, // No specific ID for this call
                Model = user // Data to be sent in the request body
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<CreateUser>(apiCall);

            // Check if the result is null, indicating a connection error
            return result == null ? apiCallHelper.ConnetionError() :
                                    // If the result is not null, process and return the service response
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Method to log in a user
        public async Task<LoginResponse> LoginUser(LoginUser user)
        {
            // Get a private HttpClient instance for making authenticated API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object to encapsulate the details of the API request
            var apiCall = new ApiCall
            {
                Route = Constant.Authentication.Login, // API endpoint for user login
                Client = client, // HttpClient instance
                Type = Constant.ApiCallType.Post, // HTTP method type
                Id = null, // No specific ID for this call
                Model = user // Data to be sent in the request body
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<LoginUser>(apiCall);

            // Check if the result is null, indicating a connection error
            return result == null ? new LoginResponse(Message: apiCallHelper.ConnetionError().Message) :
                                    // If the result is not null, process and return the login response
                                    await apiCallHelper.GetServiceResponse<LoginResponse>(result);
        }

        // Method to revive a token using a refresh token
        public async Task<LoginResponse> ReviveToken(string refreshToken)
        {
            // Get a public HttpClient instance for making unauthenticated API calls
            var client = httpClientHelper.GetPublicHttpClient();

            // Create an ApiCall object to encapsulate the details of the API request
            var apiCall = new ApiCall
            {
                Route = Constant.Authentication.ReviveToken, // API endpoint for reviving token
                Client = client, // HttpClient instance
                Type = Constant.ApiCallType.Get, // HTTP method type
                Id = HttpUtility.UrlEncode(refreshToken), // URL encode the refresh token
                Model = null // No data to be sent in the request body
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);

            // Check if the result is null, indicating a connection error
            return result == null ? null! :
                                    // If the result is not null, process and return the login response
                                    await apiCallHelper.GetServiceResponse<LoginResponse>(result);
        }
    }
}
