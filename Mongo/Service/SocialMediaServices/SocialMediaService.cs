using AutoMapper;
using Mongo.Dtos.SocialMediaDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IMongoCollection<SocialMedia> _socialmediaCollection;
        private readonly IMapper _mapper;

        public SocialMediaService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _socialmediaCollection = database.GetCollection<SocialMedia>(_databaseSettings.SocialMediaCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            await _socialmediaCollection.InsertOneAsync(value);
        }

        public async Task DeleteSocialMediaAsync(string deleteSocialMediaId)
        {
            await _socialmediaCollection.DeleteOneAsync(x => x.SocialMediaId == deleteSocialMediaId);
        }

        public async Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync()
        {
            var value = await _socialmediaCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(value);
        }

        public async Task<GetSocialMediaByIdDto> GetSocialMediaByIdAsync(string getSocialMediaById)
        {
            var value = await _socialmediaCollection.Find(x => x.SocialMediaId == getSocialMediaById).FirstOrDefaultAsync();
            return _mapper.Map<GetSocialMediaByIdDto>(value);
        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            await _socialmediaCollection.FindOneAndReplaceAsync(x => x.SocialMediaId == updateSocialMediaDto.SocialMediaId, value);

        }
    }
}
