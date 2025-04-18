using OrderService.Dtos;

namespace OrderService.Clients
{
    public class BookClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BookClient> _logger;

        public BookClient(HttpClient httpClient, ILogger<BookClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/books/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Book with ID {BookId} not found", id);
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<BookDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling CatalogService");
                return null;
            }
        }
    }
}
