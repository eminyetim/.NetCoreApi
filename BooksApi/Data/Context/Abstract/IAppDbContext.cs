using System.Runtime.CompilerServices;
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data.Abstract
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Writer> Writers { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Company> Companies {get;set;}
        DbSet<User> Users {get;set;}
        Task<int> SaveChangesAsync();

    }
}