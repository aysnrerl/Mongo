using AutoMapper;
using Mongo.Dtos.AboutListDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.AboutListServices
{
    public class AboutListService : IAboutListService
    {
        private readonly IMongoCollection<AboutList> _aboutListCollection;
        private readonly IMapper _mapper;

        public AboutListService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutListCollection = database.GetCollection<AboutList>(_databaseSettings.AboutListCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutListAsync(CreateAboutListDto createAboutListDto)
        {
            var value = _mapper.Map<AboutList>(createAboutListDto);
            await _aboutListCollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutListAsync(string deleteAboutListId)
        {
            await _aboutListCollection.DeleteOneAsync(x => x.AboutListId == deleteAboutListId);
        }

        public async Task<GetAboutListByIdDto> GetAboutListByIdAsync(string getAboutListById)
        {
            var value = _aboutListCollection.Find(x => x.AboutListId == getAboutListById).FirstOrDefault();
            return _mapper.Map<GetAboutListByIdDto>(value);
        }

        public async Task<List<ResultAboutListDto>> GetAllAboutListAsync()
        {
            var value = await _aboutListCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutListDto>>(value);

        }

        public async Task UpdateAboutListAsync(UpdateAboutListDto updateAboutListDto)
        {
           var value = _mapper.Map<AboutList>(updateAboutListDto);
            await _aboutListCollection.FindOneAndReplaceAsync(x => x.AboutListId == updateAboutListDto.AboutListId, value);
        }
    }
}
