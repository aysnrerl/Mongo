using AutoMapper;
using Mongo.Dtos.AboutSection2Dto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.AboutSection2Services
{
    public class AboutSection2Service : IAboutSection2Service
    {
        private readonly IMongoCollection<AboutSection2> _aboutSection2Collection;
        private readonly IMapper _mapper;

        public AboutSection2Service(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutSection2Collection = database.GetCollection<AboutSection2>(_databaseSettings.AboutSection2CollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutSection2Async(CreateAboutSection2Dto createAboutSection2Dto)
        {
            var value = _mapper.Map<AboutSection2>(createAboutSection2Dto);
            await _aboutSection2Collection.InsertOneAsync(value);
        }

        public async Task DeleteAboutSection2Async(string deleteAboutSection2Id)
        {
            await _aboutSection2Collection.DeleteOneAsync(x => x.AboutSection2Id == deleteAboutSection2Id);
        }

        public async Task<GetAboutSection2ByIdDto> GetAboutSection2ByIdAsync(string getAboutSection2ById)
        {
            var value = _aboutSection2Collection.Find(x => x.AboutSection2Id == getAboutSection2ById).FirstOrDefault();
            return _mapper.Map<GetAboutSection2ByIdDto>(value);
        }

        public async Task<List<ResultAboutSection2Dto>> GetAllAboutSection2Async()
        {
            var value = await _aboutSection2Collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutSection2Dto>>(value);
        }

        public async Task UpdateAboutSection2Async(UpdateAboutSection2Dto updateAboutSection2Dto)
        {
            var value = _mapper.Map<AboutSection2>(updateAboutSection2Dto);
            await _aboutSection2Collection.FindOneAndReplaceAsync(x => x.AboutSection2Id == updateAboutSection2Dto.AboutSection2Id, value);
        }
    }
}
