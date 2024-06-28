namespace ProductManagement.Models
{
    public class Product
    {
        public Guid ProductId { get; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductAmount { get; set; }
    }
}
