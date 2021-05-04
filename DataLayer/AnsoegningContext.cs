using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class AnsoegningContext : DbContext
    {
        public AnsoegningContext(DbContextOptions<AnsoegningContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(T => T.ID);

            modelBuilder.Entity<User>()
                .HasData(
                new User { ID = 1, name = "Test User", age = 27, gender = Gender.Mand },
                new User { ID = 2, name = "Test User 2", age = 59, gender = Gender.Kvinde }
                );
        }
    }
}
