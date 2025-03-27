using ClientLibrary.Models.Product;
using ClientLibrary.Models;

namespace ClientLibrary.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetProduct>> GetAllProductAsync();
        Task<GetProduct> GetProductByIdAsync(Guid id);
        Task<ServiceResponse> AddProductAsync(CreateProduct product);
        Task<ServiceResponse> UpdateProductAsync(UpdateProduct product);
        Task<ServiceResponse> DeleteProductAsync(Guid id);
    }
}
