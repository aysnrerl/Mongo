using AutoMapper;
using Mongo.Dtos.StoryVideoDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.StoryVideoServices
{
    public class StoryVideoService : IStoryVideoService
    {
        private readonly IMongoCollection<StoryVideo> _storyvideoCollection;
        private readonly IMapper _mapper;

        public StoryVideoService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _storyvideoCollection = database.GetCollection<StoryVideo>(_databaseSettings.StoryVideoCollectionName);
            _mapper = mapper;
        }

        public async Task CreateStoryVideoAsync(CreateStoryVideoDto createStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(createStoryVideoDto);
            await _storyvideoCollection.InsertOneAsync(value);
        }

        public async Task DeleteStoryVideoAsync(string deleteStoryVideoId)
        {
            await _storyvideoCollection.DeleteOneAsync(x => x.StoryVideoId == deleteStoryVideoId);
        }

        public async Task<List<ResultStoryVideoDto>> GetAllStoryVideoAsync()
        {
            var value = await _storyvideoCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultStoryVideoDto>>(value);
        }

        public async Task<GetStoryVideoByIdDto> GetStoryVideoByIdAsync(string getStoryVideoById)
        {
            var value = await _storyvideoCollection.Find(x => x.StoryVideoId == getStoryVideoById).FirstOrDefaultAsync();
            return _mapper.Map<GetStoryVideoByIdDto>(value);
        }

        public async Task UpdateStoryVideoAsync(UpdateStoryVideoDto updateStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(updateStoryVideoDto);
            await _storyvideoCollection.FindOneAndReplaceAsync(x => x.StoryVideoId == updateStoryVideoDto.StoryVideoId, value);
        }
    }
}
