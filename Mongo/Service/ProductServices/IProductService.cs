using Mongo.Dtos.ProductDto;

namespace Mongo.Service.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string deleteProductId);
        Task<GetProductByIdDto> GetProductByIdAsync(string getProductByIdId);
        
    }
}
