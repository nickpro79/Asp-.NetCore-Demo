using AspNetWebAPI.Models;
namespace AspNetWebAPI.Repository
{
    public class CustomerInMemoryRepository:ICustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public CustomerInMemoryRepository() { 
        _customerList.Add(new Customer() {Name="John",Email="John@test.com"});
        _customerList.Add(new Customer() {Name="Tina",Email="Tina@test.com" });
        _customerList.Add(new Customer() {Name="Sree",Email="Sree@test.com" });
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }
        public Customer GetCustomerById(int id)
        {
            var c = _customerList.FirstOrDefault(x => x.Id == id);
            return c;
        }
        public bool AddCustomer(Customer c)
        {
            if(c== null) { return false; }
            _customerList.Add(c);
            return true;
        }

        public Customer UpdateCustomer(int id, Customer c)
        {
            var existingCustomer = _customerList.FirstOrDefault(x=>x.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = c.Name;
                existingCustomer.Email = c.Email;
                return existingCustomer;
            }
            return null;
        }

        public bool DeleteCustomer(int id)
        {
            var c = _customerList.FirstOrDefault(c=>c.Id == id);
            if(c != null)
            {
               _customerList.Remove(c);
                return true;
            }
            return false;
        }
    }
}
