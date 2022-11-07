using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Models
{
    public class BookStore
    {
        public int Id { get; set; }

        public string ?BookName { get; set; }

        public string? Author { get; set; }
    }
}
