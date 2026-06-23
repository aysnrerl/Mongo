using Mongo.Dtos.OrderDto;

namespace Mongo.Service.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(string deleteOrderId);
        Task<GetOrderByIdDto> GetOrderByIdAsync(string getOrderById);
    }
}
