using BookService.Models;

namespace BookService.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        void Add(Book book);
    }
}
