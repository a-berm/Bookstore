using BookService.Interfaces;
using BookService.Models;

namespace BookService.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();

        public BookService()
        {
            _books = InitializeBooks();
        }

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }

        private List<Book> InitializeBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A novel set in the Roaring Twenties.", Price = 10.99m },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "A novel about racial injustice in the Deep South.", Price = 7.99m },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Description = "A dystopian novel about totalitarianism.", Price = 8.99m },
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Description = "A classic romance novel.", Price = 6.99m },
                new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Description = "A novel about teenage rebellion.", Price = 9.99m },
                new Book { Id = 6, Title = "The Hobbit", Author = "J.R.R. Tolkien", Description = "A fantasy novel about a hobbit's adventure.", Price = 12.99m },
                new Book { Id = 7, Title = "Moby-Dick", Author = "Herman Melville", Description = "A novel about the quest to catch a giant whale.", Price = 11.99m },
                new Book { Id = 8, Title = "War and Peace", Author = "Leo Tolstoy", Description = "A novel set during the Napoleonic Wars.", Price = 14.99m },
                new Book { Id = 9, Title = "The Odyssey", Author = "Homer", Description = "An epic poem about Odysseus' journey home.", Price = 13.99m },
                new Book { Id = 10, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Description = "A novel about guilt and redemption.", Price = 10.49m }
            };
        }
    }
}
