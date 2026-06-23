using AutoMapper;
using Mongo.Dtos.AboutSection1Dto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.AboutSection1Services
{
    public class AboutSection1Service : IAboutSection1Service
    {
        private readonly IMongoCollection<AboutSection1> _aboutSection1Collection;
        private readonly IMapper _mapper;

        public AboutSection1Service(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutSection1Collection = database.GetCollection<AboutSection1>(_databaseSettings.AboutSection1CollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutSection1Async(CreateAboutSection1Dto createAboutSection1Dto)
        {
            var value = _mapper.Map<AboutSection1>(createAboutSection1Dto);
            await _aboutSection1Collection.InsertOneAsync(value);
        }

        public async Task DeleteAboutSection1Async(string deleteAboutSection1Id)
        {
            await _aboutSection1Collection.DeleteOneAsync(x => x.AboutSection1Id == deleteAboutSection1Id);
        }

        public async Task<GetAboutSection1ByIdDto> GetAboutSection1ByIdAsync(string getAboutSection1ById)
        {
            var value = _aboutSection1Collection.Find(x => x.AboutSection1Id == getAboutSection1ById).FirstOrDefault();
            return _mapper.Map<GetAboutSection1ByIdDto>(value);
        }

        public async Task<List<ResultAboutSection1Dto>> GetAllAboutSection1Async()
        {
            var value = await _aboutSection1Collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutSection1Dto>>(value);
        }

        public async Task UpdateAboutSection1Async(UpdateAboutSection1Dto updateAboutSection1Dto)
        {
            var value = _mapper.Map<AboutSection1>(updateAboutSection1Dto);
            await _aboutSection1Collection.FindOneAndReplaceAsync(x => x.AboutSection1Id == updateAboutSection1Dto.AboutSection1Id, value);
        }
    }
}
