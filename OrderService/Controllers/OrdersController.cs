using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Interfaces;
using OrderService.Dtos;
using OrderService.Clients;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly BookClient _bookClient;

    public OrdersController(IOrderService orderService, BookClient bookClient)
    {
        _orderService = orderService;
        _bookClient = bookClient;

    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> Get()
    {
        var orders = _orderService.GetAll();
        var orderDtos = orders.Select(o => new OrderDto
        {
            Id = o.Id,
            BookId = o.BookId,
            BookTitle = o.BookTitle,
            BookPrice = o.BookPrice,
            Quantity = o.Quantity,
            OrderedAt = o.OrderedAt,
            Status = o.Status.ToString(),
        });
        return Ok(orderDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<OrderDto> Get(int id)
    {
        var order = _orderService.GetById(id);

        return order == null ? NotFound() : Ok(new OrderDto
        {
            Id = order.Id,
            BookId = order.BookId,
            BookTitle = order.BookTitle,
            BookPrice = order.BookPrice,
            Quantity = order.Quantity,
            OrderedAt = order.OrderedAt,
            Status = order.Status.ToString(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderDto payload)
    {
        var book = await _bookClient.GetBookByIdAsync(payload.BookId);
        if (book == null)
            return BadRequest("Invalid Book ID");

        var order = new Order()
        {
            BookId = book.Id,
            BookTitle = book.Title,
            BookPrice = book.Price,
            Quantity = payload.Quantity,
            OrderedAt = DateTime.Now,
            Status = OrderStatus.Created
        };

        _orderService.Add(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
}
