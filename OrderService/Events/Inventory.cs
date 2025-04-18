namespace OrderService.Events
{
    public record StockReserved(int OrderId, int ProductId, int Quantity);
    public record StockNotAvailable(int OrderId, int ProductId, int Quantity);
}
