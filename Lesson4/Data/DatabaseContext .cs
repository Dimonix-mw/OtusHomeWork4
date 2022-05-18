using Microsoft.EntityFrameworkCore;
using Lesson4.Models;

namespace Lesson4.Data
{
    public class DatabaseContext : DbContext
    {
        /*public DatabaseContext() 
        { 
        }*/

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeAnnouncement> TypeAnnouncements { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Announcement>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<TypeAnnouncement>();
            modelBuilder.Entity<TypeProduct>();
        }
    }
}
