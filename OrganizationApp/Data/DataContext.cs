using Microsoft.EntityFrameworkCore;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ChoreItem> choreItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChoreItem>().HasData(new { Id = 1, AssignedTo = "Adam", CreatedDate = DateTime.Now, IsComplete = false, Name = "Dishes" });
        }
    }
}
