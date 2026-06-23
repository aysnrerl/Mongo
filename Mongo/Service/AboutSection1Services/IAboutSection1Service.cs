using Mongo.Dtos.AboutSection1Dto;

namespace Mongo.Service.AboutSection1Services
{
    public interface IAboutSection1Service
    {
        Task<List<ResultAboutSection1Dto>> GetAllAboutSection1Async();
        Task CreateAboutSection1Async(CreateAboutSection1Dto createAboutSection1Dto);
        Task UpdateAboutSection1Async(UpdateAboutSection1Dto updateAboutSection1Dto);
        Task DeleteAboutSection1Async(string deleteAboutSection1Id);
        Task<GetAboutSection1ByIdDto> GetAboutSection1ByIdAsync(string getAboutSection1ById);
    }
}
