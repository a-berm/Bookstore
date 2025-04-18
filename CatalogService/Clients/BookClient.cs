using CatalogService.Dtos;

namespace CatalogService.Clients
{
    public class BookClient
    {
        private readonly HttpClient _http;

        public BookClient(HttpClient http) => _http = http;

        public async Task<List<BookDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<BookDto>>("api/books");
            return result ?? [];
        }
    }
    //public record Book(int Id, string Title, decimal Price);
}
