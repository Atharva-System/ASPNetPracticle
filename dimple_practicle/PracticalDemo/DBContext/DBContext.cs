using Microsoft.EntityFrameworkCore;
using PracticalDemoWebAPI.Models;

namespace PracticalDemoWebAPI.DBContext
{
    public class DBContextClass : DbContext
    {
        public DBContextClass(DbContextOptions<DBContextClass> options) : base(options)  
        {
                
        }
        public DbSet<CarInventoryModel> carInventroys { get; set; }
    }
}
