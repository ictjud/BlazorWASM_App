using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;

namespace ClientLibrary.Services
{
    public class CategoryService(IHttpClientHelper httpClientHelper, IApiCallHelper apiCallHelper)
            : ICategoryService
    {
        // Private, for only administrator or authorized user
        public async Task<ServiceResponse> AddCategoryAsync(CreateCategory category)
        {
            // Get a private HttpClient instance for making authenticated API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object to encapsulate the details of the API request
            var apiCall = new ApiCall
            {
                Route = Constant.Category.Add, // API endpoint for adding a category
                Type = Constant.ApiCallType.Post, // HTTP method type
                Client = client, // HttpClient instance
                Id = null!, // No ID needed for adding a new category
                Model = category // The category data to be sent in the request body
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<CreateCategory>(apiCall);

            // Check if the result is null, indicating a connection error
            return result == null ? apiCallHelper.ConnetionError() :
                                    // If the result is not null, process the response and return it
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Private, for only administrator or authorized user 
        public async Task<ServiceResponse> DeleteCategoryAsync(Guid id)
        {
            // Get a private HttpClient instance for making authenticated API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object to encapsulate the details of the API request
            var apiCall = new ApiCall
            {
                //Route = $"{Constant.Category.Delete}/{id}", // API endpoint for deleting a category
                Route = Constant.Category.Delete, // API endpoint for deleting a category
                Type = Constant.ApiCallType.Delete, // HTTP method type
                Client = client, // HttpClient instance
                //Id = id.ToString(), // ID of the category to be deleted
                Model = null // No model needed for delete request
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);

            // Check if the result is null, indicating a connection error
            return result == null ? apiCallHelper.ConnetionError() :
                                    // If the result is not null, process the response and return it
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Private, for only administrator or authorized user
        public async Task<ServiceResponse> UpdateCategoryAsync(UpdateCategory category)
        {
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            var apiCall = new ApiCall
            {
                Route = Constant.Category.Update,
                Type = Constant.ApiCallType.Put,
                Client = client,
                Id = category.Id.ToString(),
                Model = category
            };

            var result = await apiCallHelper.ApiCallTypeCall<UpdateCategory>(apiCall);
            return result == null ? apiCallHelper.ConnetionError() :
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Public, for all users
        public async Task<IEnumerable<GetCategory>> GetAllCategoryAsync()
        {
            var client = httpClientHelper.GetPublicHttpClient();
            var apiCall = new ApiCall 
            {
                Route = Constant.Category.GetAll,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = null,
                Model = null
            };
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);
            return result == null ? [] :
                await apiCallHelper.GetServiceResponse<IEnumerable<GetCategory>>(result);
        }

        // Public, for all users
        public async Task<GetCategory> GetCategoryByIdAsync(Guid id)
        {
            var client = httpClientHelper.GetPublicHttpClient();
            var apiCall = new ApiCall {
                Route = Constant.Category.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = id.ToString(),
                Model = null
            };
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);
            return result == null ? null! :
                await apiCallHelper.GetServiceResponse<GetCategory>(result);
        }

        // Public, for all users
        public async Task<IEnumerable<GetProduct>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var client = httpClientHelper.GetPublicHttpClient();

            var apiCall = new ApiCall
            {
                Route = Constant.Category.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = categoryId.ToString(),
                Model = null
            };
            // apiCall.ToString(categoryId);
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);
            return result == null ? [] : 
                await apiCallHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);
        }
    }
}
