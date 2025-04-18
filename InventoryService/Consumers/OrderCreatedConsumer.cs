using InventoryService.Events;
using InventoryService.Interfaces;
using MassTransit;

namespace InventoryService.Consumers
{
    class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly IStockService _stockService;
        private readonly ILogger<OrderCreatedConsumer> _logger;

        public OrderCreatedConsumer(IStockService stockService, ILogger<OrderCreatedConsumer> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            var message = context.Message;

            _logger.LogInformation("Received OrderCreated: {OrderId}", message.OrderId);

            if (_stockService.TryReserve(message.ProductId, message.Quantity))
            {
                _logger.LogInformation("Stock reserved for order {OrderId}.", message.OrderId);
                return context.Publish(new StockReserved(message.OrderId, message.ProductId, message.Quantity));
            }
            else
            {
                _logger.LogWarning("Stock not available for order {OrderId}.", message.OrderId);
                return context.Publish(new StockNotAvailable(message.OrderId, message.ProductId, message.Quantity));
            }
        }
    }
}
