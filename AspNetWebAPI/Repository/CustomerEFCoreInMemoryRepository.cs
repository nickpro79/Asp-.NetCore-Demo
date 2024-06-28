using AspNetWebAPI.Data;
using AspNetWebAPI.Models;

namespace AspNetWebAPI.Repository
{
    public class CustomerEFCoreInMemoryRepository : ICustomerRepository
    {
        CustomerDbContext _dbContext;
        public CustomerEFCoreInMemoryRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCustomer(Customer c)
        {
           _dbContext.Customers.Add(c);
           _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var deleteCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (deleteCustomer != null) { 
            _dbContext.Customers.Remove(deleteCustomer);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            var c = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            return c;
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null) {
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            _dbContext.SaveChanges();
            }
            return existingCustomer;
        }
    }
}
