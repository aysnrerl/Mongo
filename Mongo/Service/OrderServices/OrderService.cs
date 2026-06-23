using AutoMapper;
using Mongo.Dtos.OrderDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Order>(createOrderDto);

            // Otomatik hesaplanan ve atanan sipariş değerleri
            value.OrderDate = DateTime.Now;
            value.Status = "Beklemede";
            value.TotalPrice = createOrderDto.Quantity * createOrderDto.UnitPrice;

            await _orderCollection.InsertOneAsync(value);
        }

        public async Task DeleteOrderAsync(string deleteOrderId)
        {
            await _orderCollection.DeleteOneAsync(x => x.OrderId == deleteOrderId);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var value = await _orderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(value);
        }

        public async Task<GetOrderByIdDto> GetOrderByIdAsync(string getOrderById)
        {
            var value = await _orderCollection.Find(x => x.OrderId == getOrderById).FirstOrDefaultAsync();
            return _mapper.Map<GetOrderByIdDto>(value);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var value = _mapper.Map<Order>(updateOrderDto);
            await _orderCollection.FindOneAndReplaceAsync(x => x.OrderId == updateOrderDto.OrderId, value);
        }
    }
}
