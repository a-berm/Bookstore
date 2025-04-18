namespace InventoryService.Events
{
    public record OrderCreated(int OrderId, int ProductId, int Quantity, DateTime CreatedAt);
}
