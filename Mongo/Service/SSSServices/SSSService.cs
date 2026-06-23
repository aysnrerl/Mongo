using AutoMapper;
using Mongo.Dtos.SSSDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.SSSServices
{
    public class SSSService : ISSSService
    {
        private readonly IMongoCollection<SSS> _serviceCollections;
        private readonly IMapper _mapper;

        public SSSService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollections = database.GetCollection<SSS>(_databaseSettings.SSSCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSSSAsync(CreateSSSDto createSSSDto)
        {
           var value = _mapper.Map<SSS>(createSSSDto);
            await _serviceCollections.InsertOneAsync(value);
        }

        public async Task DeleteSSSAsync(string deleteSSSId)
        {
            await _serviceCollections.DeleteOneAsync(x => x.SSSId == deleteSSSId);
        }

        public async Task<List<ResultSSSDto>> GetAllSSSAsync()
        {
            var value = await _serviceCollections.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSSSDto>>(value);
        }

        public async Task<GetSSSByIdDto> GetSSSByIdAsync(string getSSSById)
        {
            var value = await _serviceCollections.Find(x => x.SSSId == getSSSById).FirstOrDefaultAsync();
            return _mapper.Map<GetSSSByIdDto>(value);
        }

        public async Task UpdateSSSAsync(UpdateSSSDto updateSSSDto)
        {
            var value = _mapper.Map<SSS>(updateSSSDto);
            await _serviceCollections.FindOneAndReplaceAsync(x => x.SSSId == updateSSSDto.SSSId, value);
        }
    }
}
