namespace InventoryService.Interfaces
{
    public interface IStockService
    {
        object GetAll();

        bool TryReserve(int productId, int quantity);

        void UpdateStock(int productId, int quantity);
    }
}
