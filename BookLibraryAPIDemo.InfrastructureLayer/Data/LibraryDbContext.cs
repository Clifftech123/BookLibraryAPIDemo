using BookLibraryAPIDemo.InfrastructureLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPIDemo.InfrastructureLayer.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }


        // Adding book to the database 
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
