using ClientLibrary.Models;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;

namespace ClientLibrary.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllCategoryAsync();
        Task<GetCategory> GetCategoryByIdAsync(Guid id);
        Task<ServiceResponse> AddCategoryAsync(CreateCategory category);
        Task<ServiceResponse> UpdateCategoryAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteCategoryAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductsByCategoryAsync(Guid categoryId);
    }
}
