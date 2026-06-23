using Mongo.Dtos.SubscribeDto;

namespace Mongo.Service.SubscribeServices
{
    public interface ISubscribeService
    {
        Task<List<ResultSubscribeDto>> GetAllSubscribeAsync();
        Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto);
        Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto);
        Task DeleteSubscribeAsync(string deleteSubscribeId);
        Task<GetSubscribeByIdDto> GetSubscribeByIdAsync(string getSubscribeById);
    }
}
