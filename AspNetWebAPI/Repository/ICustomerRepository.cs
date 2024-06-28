using AspNetWebAPI.Models;
namespace AspNetWebAPI.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers();

        public Customer GetCustomerById(int id);

        public bool AddCustomer(Customer c);

        public Customer UpdateCustomer(int id, Customer customer);

        public bool DeleteCustomer(int id);
    }
}
