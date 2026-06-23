using Mongo.Dtos.MnogoDto;

namespace Mongo.Service.StatisticServices
{
    public interface IStatisticService
    {
        Task<AdminDashboardViewModel> GetDashboardOverviewAsync();
    }
}
