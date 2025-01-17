using System.Runtime.CompilerServices;
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Abstract
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Writer> Writers { get; set; }
        DbSet<Genre> Genres { get; set; }
        Task<int> SaveChangesAsync();

    }
}