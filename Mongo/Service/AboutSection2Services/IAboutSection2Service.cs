using Mongo.Dtos.AboutSection2Dto;

namespace Mongo.Service.AboutSection2Services
{
    public interface IAboutSection2Service
    {
        Task<List<ResultAboutSection2Dto>> GetAllAboutSection2Async();
        Task CreateAboutSection2Async(CreateAboutSection2Dto createAboutSection2Dto);
        Task UpdateAboutSection2Async(UpdateAboutSection2Dto updateAboutSection2Dto);
        Task DeleteAboutSection2Async(string deleteAboutSection2Id);
        Task<GetAboutSection2ByIdDto> GetAboutSection2ByIdAsync(string getAboutSection2ById);
    }
}
