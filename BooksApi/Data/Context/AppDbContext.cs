using BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Abstract;
using WebApi.Services.Abstract;

namespace BooksApi.Data.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Book <-> Genre
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books);

            // Book <-> Writer
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Writers)
                .WithMany(w => w.Books);
        }

    }
}