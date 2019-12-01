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

        public DbSet<ChoreItem> ChoreItems { get; set; }
        public DbSet<AssignedPerson> AssignedPerson { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChoreItem>()
                .HasOne(c => c.AssignedTo)
                .WithMany(c => c.Chores)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AssignedPerson>()
                .HasMany(a => a.Chores)
                .WithOne(a => a.AssignedTo)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<ChoreItem>().HasData(new { Id = 1, AssignedTo = "Adam", CreatedDate = DateTime.Now, IsComplete = false, Name = "Dishes" });
        }
    }
}
