using SmartPhonesAPI.Data;
using SmartPhonesAPI.Models;

namespace SmartPhonesAPI.Services
{
    public class SmartPhoneRepository : ISmartphoneRepository
    {
       SmartPhoneDbContext _context;
        public bool Add(SmartPhone phone)
        {
                _context.SmartPhones.Add(phone);
                _context.SaveChanges();
                return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmartPhone> FindAllByDateAndPrice(double price)
        {
            throw new NotImplementedException();
        }

        public (double MinimumPrice, float AveragePrice) FindMinimumAndAverage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmartPhone> GetAll()
        {
            return _context.SmartPhones;     
        }

        public SmartPhone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SmartPhone Update(int id, SmartPhone phone)
        {
            throw new NotImplementedException();
        }
    }
}
