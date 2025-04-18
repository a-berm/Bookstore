using InventoryService.Dto;
using InventoryService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IStockService _stockService;

        public InventoryController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("stock")]
        public ActionResult<IEnumerable<StockDto>> GetStock()
        {
            var stock = _stockService.GetAll() as Dictionary<int, int>;
            if (stock == null)
            {
                return NotFound();
            }

            var result = stock.Select(s => new StockDto
            {
                BookId = s.Key,
                Quantity = s.Value
            }).ToList();

            return Ok(result);
        }

        [HttpPost("update-stock")]
        public ActionResult<IEnumerable<StockDto>> UpdateStock(StockDto stock)
        {
            try
            {
                _stockService.UpdateStock(stock.BookId, stock.Quantity);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
