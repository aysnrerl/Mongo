using Mongo.Dtos.AboutListDto;

namespace Mongo.Service.AboutListServices
{
    public interface IAboutListService
    {
        Task<List<ResultAboutListDto>> GetAllAboutListAsync();
        Task CreateAboutListAsync(CreateAboutListDto createAboutListDto);
        Task UpdateAboutListAsync(UpdateAboutListDto updateAboutListDto);
        Task DeleteAboutListAsync(string deleteAboutListId);
        Task<GetAboutListByIdDto> GetAboutListByIdAsync(string getAboutListById);
    }
}
