using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SignalRTest.Models;

namespace SignalRTest.Data
{
    public class AppDbContext :DbContext
    {
       public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource = shgdhe.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
