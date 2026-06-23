using Mongo.Dtos.FeatureDto;

namespace Mongo.Service.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string deleteFeatureId);
        Task<GetFeatureByIdDto> GetFeatureByIdAsync(string getFeatureById);
    }
}
