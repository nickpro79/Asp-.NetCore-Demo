using Microsoft.EntityFrameworkCore;
using SmartPhonesAPI.Models;

namespace SmartPhonesAPI.Data
{
    public class SmartPhoneDbContext :DbContext
    {
        public SmartPhoneDbContext(DbContextOptions options) : base(options) {
        
        }

        public DbSet<SmartPhone> SmartPhones { get; set; }
    }
}
