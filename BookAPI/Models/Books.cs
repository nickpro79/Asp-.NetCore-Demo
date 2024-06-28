namespace BookAPI.Models
{
    public class Books
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Author { get; set; }
    }
}
