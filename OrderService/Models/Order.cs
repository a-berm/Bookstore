namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }

    public int BookId { get; set; }           // Reference to the book
    public string BookTitle { get; set; } = ""; // Snapshot of the title
    public decimal BookPrice { get; set; }    // Snapshot of the price

    public int Quantity { get; set; }

    public OrderStatus Status { get; set; } 

    public DateTime OrderedAt { get; set; } 

    public DateTime UpdatedAt { get; set; } 
}

public enum OrderStatus
{
    Created,
    Confirmed,
    Failed
}
