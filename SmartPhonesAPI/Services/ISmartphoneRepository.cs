using SmartPhonesAPI.Models;

namespace SmartPhonesAPI.Services
{
    public interface ISmartphoneRepository
    {
        public IEnumerable<SmartPhone> GetAll();
        public SmartPhone GetById(int id);
        public bool Delete(int id);
        public SmartPhone Update(int id,SmartPhone phone);

        public bool Add(SmartPhone phone);
        public (double MinimumPrice, float AveragePrice) FindMinimumAndAverage();

        public IEnumerable<SmartPhone> FindAllByDateAndPrice(double price);

    }
}
