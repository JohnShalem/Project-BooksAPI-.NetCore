using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models
{
    public class BookstoreContext : DbContext
    {
        //Constructor for DbContext
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }
         
        public DbSet<BookStore> ?BookStores { get; set; }

    

    }
}
