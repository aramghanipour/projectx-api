using Microsoft.EntityFrameworkCore;

namespace ProjectX.Models
{
    public class BooksAPIContext : DbContext
    {
        public BooksAPIContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}