using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;

namespace ClientLibrary.Services
{
    public class CategoryService(IHttpClientHelper httpClientHelper, IApiCallHelper apiCallHelper)
        : ICategoryService
    {
        public Task<ServiceResponse> AddCategoryAsync(CreateCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategory>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategory> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProduct>> GetProductsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateCategoryAsync(UpdateCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
