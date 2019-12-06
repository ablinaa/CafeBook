using System;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Data
{
    public class CafeBookContext:DbContext
    {
        public CafeBookContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Identity> Identity { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<RentSchedule> RentSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to one
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Identity)
                .WithOne(i => i.User)
                .HasForeignKey<Identity>(i => i.UserId);

            //one to many
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookType)
                .WithMany(bt => bt.Books);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.FoodType)
                .WithMany(ft => ft.Foods);

            //many to many
            modelBuilder.Entity<RentSchedule>()
                .HasOne(rs => rs.Book)
                .WithMany(b => b.RentSchedule);

            modelBuilder.Entity<RentSchedule>()
                .HasOne(rs => rs.User)
                .WithMany(u => u.RentSchedule);
        }
    }
}
