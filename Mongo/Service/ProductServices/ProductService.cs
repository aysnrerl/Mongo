using AutoMapper;
using Mongo.Dtos.ProductDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productsCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string deleteProductId)
        {
            await _productsCollection.DeleteOneAsync(x => x.ProductId == deleteProductId);
        }

    
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var value = await _productsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string getProductByIdId)
        {
            var value = await _productsCollection.Find(x => x.ProductId == getProductByIdId).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productsCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}