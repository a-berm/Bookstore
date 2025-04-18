namespace OrderService.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int BookId { get; set; }           

        public string BookTitle { get; set; } = ""; 

        public decimal BookPrice { get; set; }   

        public int Quantity { get; set; }

        public string? Status { get; set; }

        public DateTime OrderedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
