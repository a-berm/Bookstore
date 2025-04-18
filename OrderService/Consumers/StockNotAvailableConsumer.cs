using OrderService.Events;
using MassTransit;
using OrderService.Interfaces;
using OrderService.Models;

namespace OrderService.Consumers
{
    public class StockNotAvailableConsumer : IConsumer<StockNotAvailable>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<StockReservedConsumer> _logger;

        public StockNotAvailableConsumer(ILogger<StockReservedConsumer> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;

        }

        public Task Consume(ConsumeContext<StockNotAvailable> context)
        {
            var message = context.Message;
            _logger.LogWarning("Stock not available confirmation for order {OrderId}", message.OrderId);
            var order = _orderService.GetById(message.OrderId);
            order.UpdatedAt = DateTime.UtcNow;
            order.Status = OrderStatus.Failed;
            return Task.CompletedTask;
        }
    }
}
