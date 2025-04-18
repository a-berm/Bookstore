using CatalogService.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly BookClient bookClient;
        private readonly InventoryClient inventoryClient;

        public CatalogController(BookClient bookClient, InventoryClient inventoryClient)
        {
            this.bookClient = bookClient;
            this.inventoryClient = inventoryClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetGatalog()
        {
            var books = await bookClient.GetAllAsync();
            var stocks = await inventoryClient.GetAllAsync();

            var stockDictionary = stocks.ToDictionary(stock => stock.BookId, stock => stock.Quantity);

            var result = books.Select(book =>
            {
                stockDictionary.TryGetValue(book.Id, out var quantity);
                return new CatalogItem
                (
                    book.Id,
                    book.Title,
                    book.Author,
                    book.Description,
                    book.Price,
                    quantity
                );
            });

            return Ok(result);
        }
    }
    public record CatalogItem(int BookId, string Title, string Author, string Description ,decimal Price, int Quantity);

}
