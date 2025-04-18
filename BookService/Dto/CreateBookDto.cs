namespace BookService.Dto
{
    public class CreateBookDto
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public decimal Price { get; set; }
    }
}
