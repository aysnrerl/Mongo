using Mongo.Dtos.SocialMediaDto;

namespace Mongo.Service.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync();
        Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
        Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto);
        Task DeleteSocialMediaAsync(string deleteSocialMediaId);
        Task<GetSocialMediaByIdDto> GetSocialMediaByIdAsync(string getSocialMediaById);
    }
}
