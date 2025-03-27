using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Product;

namespace ClientLibrary.Services
{
    public class ProductService(IHttpClientHelper httpClientHelper, IApiCallHelper apiCallHelper) : IProductService
    {
        // Private, for only administrator or authorized user
        public async Task<ServiceResponse> AddProductAsync(CreateProduct product)
        {
            // Get a private HttpClient instance for making authorized API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object with necessary details for adding a product
            var apiCall = new ApiCall
            {
                Route = Constant.Product.Add, // API route for adding a product
                Type = Constant.ApiCallType.Post, // HTTP method type
                Client = client, // HttpClient instance
                Id = null, // No ID needed for adding a new product
                Model = product // Product data to be sent in the request body
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<CreateProduct>(apiCall);

            // Return the service response based on the API call result
            return result == null ? apiCallHelper.ConnetionError() :
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Private, for only administrator or authorized user
        public async Task<ServiceResponse> DeleteProductAsync(Guid id)
        {
            // Get a private HttpClient instance for making authorized API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object with necessary details for deleting a product
            var apiCall = new ApiCall
            {
                Route = Constant.Product.Delete, // API route for deleting a product
                Type = Constant.ApiCallType.Delete, // HTTP method type
                Client = client, // HttpClient instance
                Id = id.ToString(), // ID of the product to be deleted
                Model = null // No model needed for delete operation
            };

            // Convert the ID to string format (this line seems redundant and can be removed)
            apiCall.ToString(id);

            // Make the API call and get the response using Dummy as a placeholder for the generic type
            var result = await apiCallHelper.ApiCallTypeCall<Dummy>(apiCall);

            // Return the service response based on the API call result
            return result == null ? apiCallHelper.ConnetionError() :
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }
        // Private, for only administrator or authorized user
        public async Task<ServiceResponse> UpdateProductAsync(UpdateProduct product)
        {
            // Get a private HttpClient instance for making authorized API calls
            var client = await httpClientHelper.GetPrivateHttpClientAsync();

            // Create an ApiCall object with necessary details for updating a product
            var apiCall = new ApiCall
            {
                Route = Constant.Product.Update, // API route for updating a product
                Type = Constant.ApiCallType.Put, // HTTP method type (PUT for update)
                Client = client, // HttpClient instance
                Id = product.Id.ToString(), // ID of the product to be updated
                Model = product // Product data to be sent in the request body
            };

            // Convert the product ID to string format (this line seems redundant and can be removed)
            apiCall.ToString(product.Id);

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<UpdateProduct>(apiCall);

            // Return the service response based on the API call result
            return result == null ? apiCallHelper.ConnetionError() :
                                    await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Public, for all users
        public async Task<IEnumerable<GetProduct>> GetAllProductAsync()
        {
            // Get a public HttpClient instance for making API calls
            var client = httpClientHelper.GetPublicHttpClient();

            // Create an ApiCall object with necessary details for getting all products
            var apiCall = new ApiCall
            {
                Route = Constant.Product.GetAll, // API route for getting all products
                Type = Constant.ApiCallType.Get, // HTTP method type
                Client = client, // HttpClient instance
                Id = null, // No ID needed for getting all products
                Model = null // No model needed for get operation
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<IEnumerable<GetProduct>>(apiCall);

            // Return the service response based on the API call result
            return result == null ? [] :
                                    await apiCallHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);
        }

        // Public, for all users
        public async Task<GetProduct> GetProductByIdAsync(Guid id)
        {
            // Get a public HttpClient instance for making API calls
            var client = httpClientHelper.GetPublicHttpClient();

            // Create an ApiCall object with necessary details for getting a product by ID
            var apiCall = new ApiCall
            {
                Route = Constant.Product.Get, // API route for getting a product by ID
                Type = Constant.ApiCallType.Get, // HTTP method type
                Client = client, // HttpClient instance
                Id = id.ToString(), // ID of the product to be retrieved
                Model = null // No model needed for get operation
            };

            // Make the API call and get the response
            var result = await apiCallHelper.ApiCallTypeCall<GetProduct>(apiCall);

            // Return the service response based on the API call result
            return result == null ? null! :
                                    await apiCallHelper.GetServiceResponse<GetProduct>(result);
        }
    }
}
