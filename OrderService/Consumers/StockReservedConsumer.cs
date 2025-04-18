using OrderService.Events;
using MassTransit;
using OrderService.Interfaces;
using OrderService.Models;

namespace OrderService.Consumers
{
    public class StockReservedConsumer : IConsumer<StockReserved>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<StockReservedConsumer> _logger;

        public StockReservedConsumer(ILogger<StockReservedConsumer> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;

        }

        public Task Consume(ConsumeContext<StockReserved> context)
        {
            var message = context.Message;
            _logger.LogInformation("Stock reserved confirmation for order {OrderId}", message.OrderId);
            var order = _orderService.GetById(message.OrderId);
            order.UpdatedAt = DateTime.UtcNow;
            order.Status = OrderStatus.Confirmed;
            return Task.CompletedTask;
        }
    }
}
