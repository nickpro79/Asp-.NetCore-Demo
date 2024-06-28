using ProductManagement.Models;

namespace ProductManagement.Services
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(Guid id);

        public bool AddProduct(Product product);

        public Product UpdateProduct(Guid id,Product product);

        public bool DeleteProduct(Guid Id);

        public IEnumerable<Product> GetProductsGreaterThanAmount(double amount);

    }
}
