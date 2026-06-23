using Mongo.Dtos.SSSDto;

namespace Mongo.Service.SSSServices
{
    public interface ISSSService
    {
        Task<List<ResultSSSDto>> GetAllSSSAsync();
        Task CreateSSSAsync(CreateSSSDto createSSSDto);
        Task UpdateSSSAsync(UpdateSSSDto updateSSSDto);
        Task DeleteSSSAsync(string deleteSSSId);
        Task<GetSSSByIdDto> GetSSSByIdAsync(string getSSSById);
    }
}
