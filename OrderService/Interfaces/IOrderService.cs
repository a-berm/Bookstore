using OrderService.Models;

namespace OrderService.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAll();
    Order? GetById(int id);
    void Add(Order order);
}
