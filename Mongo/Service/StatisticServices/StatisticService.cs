using Mongo.Dtos.MnogoDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        // Bağlanacağımız koleksiyonları tanımlıyoruz
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<SSS> _sssCollection;

        
        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _sssCollection = database.GetCollection<SSS>(_databaseSettings.SSSCollectionName);
        }

        public async Task<AdminDashboardViewModel> GetDashboardOverviewAsync()
        {
            var model = new AdminDashboardViewModel();

            model.ProductCount = await _productCollection.CountDocumentsAsync(x => true);
            model.SSSCount = await _sssCollection.CountDocumentsAsync(x => true);

            
            model.TestimonialCount = 0;

            return model;
        }
    }
}
