using InventoryService.Interfaces;

namespace InventoryService.Services
{
    public class StockService : IStockService
    {
        // Simulated stock data [id, quantity]
        private readonly Dictionary<int, int> _stock = new()
        {
            [1]  = 10,
            [2]  = 5,
            [3]  = 20,
            [4]  = 8,
            [5]  = 2,
            [6]  = 13,
            [7]  = 8,
            [8]  = 32,
            [9]  = 1,
            [10] = 3
        };

        public bool TryReserve(int productId, int quantity)
        {
            if (_stock.TryGetValue(productId, out var available) && available >= quantity)
            {
                _stock[productId] -= quantity;
                return true;
            }
            return false;
        }

        public object GetAll() => _stock;


        public void UpdateStock(int productId, int quantity)
        {
            if (!_stock.ContainsKey(productId))
            {
                throw new ArgumentException($"Product with ID {productId} does not exist.");
            }

            _stock[productId] += quantity;
        }
    }
}
