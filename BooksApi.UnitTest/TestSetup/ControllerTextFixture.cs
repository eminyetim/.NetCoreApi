using AutoMapper;
using BooksApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.UnitTest
{
    public class ControllerTextFixture
    {
        public AppDbContext Context{get;set;}
        public IMapper Mapper{get;set;}

        public ControllerTextFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName:"BookWriterDb").Options;
            Context = new AppDbContext(options);
            Context.Database.EnsureCreated();
        } 
    }
}