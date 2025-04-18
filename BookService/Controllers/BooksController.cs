using BookService.Interfaces;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => Ok(_bookService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.GetById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _bookService.Add(book);
            return CreatedAtAction("Get", new { id = book.Id }, book);
        }
    }
}
