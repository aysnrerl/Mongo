using AutoMapper;
using Mongo.Dtos.SubscribeDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.SubscribeServices
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IMongoCollection<Subscribe> _subscribeCollection;
        private readonly IMapper _mapper;

        public SubscribeService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _subscribeCollection = database.GetCollection<Subscribe>(_databaseSettings.SubscribeCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto)
        {
            var value = _mapper.Map<Subscribe>(createSubscribeDto);
            value.CreatedDate = DateTime.Now; // Kayıt tarihi otomatik atandı
            await _subscribeCollection.InsertOneAsync(value);
        }

        public async Task DeleteSubscribeAsync(string deleteSubscribeId)
        {
            await _subscribeCollection.DeleteOneAsync(x => x.SubscribeId == deleteSubscribeId);
        }

        public async Task<List<ResultSubscribeDto>> GetAllSubscribeAsync()
        {
            var value = await _subscribeCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSubscribeDto>>(value);
        }

        public async Task<GetSubscribeByIdDto> GetSubscribeByIdAsync(string getSubscribeById)
        {
            var value = await _subscribeCollection.Find(x => x.SubscribeId == getSubscribeById).FirstOrDefaultAsync();
            return _mapper.Map<GetSubscribeByIdDto>(value);
        }

        public async Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto)
        {
            var value = _mapper.Map<Subscribe>(updateSubscribeDto);
            await _subscribeCollection.FindOneAndReplaceAsync(x => x.SubscribeId == value.SubscribeId, value);
        }
    }
}
