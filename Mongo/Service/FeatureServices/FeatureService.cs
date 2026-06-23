using AutoMapper;
using Mongo.Dtos.FeatureDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);                                             
        }

        public async Task DeleteFeatureAsync(string deleteFeatureId)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == deleteFeatureId);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var value = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(value);
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string getFeatureById)
        {
            var value = await _featureCollection.Find(x => x.FeatureId == getFeatureById).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, value);
        }
    }
}
