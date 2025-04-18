using OrderService.Models;
using OrderService.Interfaces;
using MassTransit;
using OrderService.Events;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = [];
    
    //private readonly IPublishEndpoint _publishEndpoint;
    private readonly IServiceProvider _serviceProvider;


    public OrderService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IEnumerable<Order> GetAll() => _orders;

    public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

    public async void Add(Order order)
    {
        order.Id = _orders.Count + 1;
        _orders.Add(order);

        using var scope = _serviceProvider.CreateScope();
        var publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish(new OrderCreated(
            order.Id,
            order.BookId,
            order.Quantity,
            DateTime.UtcNow
        ));
    }
}
