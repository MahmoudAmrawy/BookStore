using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
