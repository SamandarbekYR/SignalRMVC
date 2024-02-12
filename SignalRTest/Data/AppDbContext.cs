﻿using Microsoft.EntityFrameworkCore;
using SignalRTest.Models;

namespace SignalRTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource =SignalRWPF.db ");
            base.OnConfiguring(optionsBuilder);
        }

    }
}