using ProductManagement.Models;
namespace ProductManagement.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();
        public ProductRepository() {
            _products.Add(new Product() { ProductName = "Wireless Mouse", ProductDescription = "Ergonomic wireless mouse with adjustable DPI settings.", ProductAmount = 25 });
            _products.Add(new Product() { ProductName = "Mechanical Keyboard", ProductDescription = "RGB backlit mechanical keyboard with customizable keys.", ProductAmount = 70 });
            _products.Add(new Product() {  ProductName = "4K Monitor", ProductDescription = "27-inch 4K UHD monitor with HDR support.", ProductAmount = 350 });
            _products.Add(new Product() { ProductName = "External Hard Drive", ProductDescription = "1TB portable external hard drive with USB 3.0 connectivity.", ProductAmount = 50 });
            _products.Add(new Product() {  ProductName = "Bluetooth Speaker", ProductDescription = "Portable Bluetooth speaker with 12 hours of battery life.", ProductAmount = 40 });
            _products.Add(new Product() {  ProductName = "Gaming Headset", ProductDescription = "Surround sound gaming headset with noise-cancelling microphone.", ProductAmount = 60 });
        }
        public IEnumerable<Product> GetProducts()
        {
                return _products;
        }
        public Product GetProductById(Guid id)
        {
            var p = _products.FirstOrDefault(x => x.ProductId == id);
            return p;
            
        }

        public bool AddProduct(Product product)
        {
            if (product == null) {
                return false;
            }
            _products.Add(product);
            return true;
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            var p = _products.FirstOrDefault(x => x.ProductId == id);
            if (p != null) { 
            p.ProductName = product.ProductName;
            p.ProductDescription = product.ProductDescription;
            p.ProductAmount = product.ProductAmount;
            }
            return p;
        }

        public bool DeleteProduct(Guid Id)
        {
            var p = _products.FirstOrDefault(x => x.ProductId == Id);
            if (p == null) {
                return false;
            }
            _products.Remove(p);
            return true;
        }

        public IEnumerable<Product> GetProductsGreaterThanAmount(double amount)
        {
            var products = _products.FindAll(x => x.ProductAmount > amount);
            return products;
        }
    }
}
