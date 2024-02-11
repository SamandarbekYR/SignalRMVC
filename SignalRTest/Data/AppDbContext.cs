using Microsoft.EntityFrameworkCore;
using SignalRTest.Models;

namespace SignalRTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource =SignalRWPF.db ");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
