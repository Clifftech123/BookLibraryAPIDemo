using BookLibraryAPIDemo.InfrastructureLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPIDemo.InfrastructureLayer.Data
{
    internal class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
