using Mongo.Dtos.StoryVideoDto;

namespace Mongo.Service.StoryVideoServices
{
    public interface IStoryVideoService
    {
        Task<List<ResultStoryVideoDto>> GetAllStoryVideoAsync();
        Task CreateStoryVideoAsync(CreateStoryVideoDto createStoryVideoDto);
        Task UpdateStoryVideoAsync(UpdateStoryVideoDto updateStoryVideoDto);
        Task DeleteStoryVideoAsync(string deleteStoryVideoId);
        Task<GetStoryVideoByIdDto> GetStoryVideoByIdAsync(string getStoryVideoById);
    }
}
