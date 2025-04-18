using CatalogService.Dto;

namespace CatalogService.Clients
{
    public class InventoryClient
    {
        private readonly HttpClient _http;

        public InventoryClient(HttpClient http) => _http = http;

        public async Task<List<StockDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<StockDto>>("api/inventory/stock");
            return result ?? new();
        }
    }
}
