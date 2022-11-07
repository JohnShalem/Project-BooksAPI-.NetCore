using BookStoreApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Model
{
    public class BookModel
    {
        public int Id { get; set; }   
        public string? BookName { get; set; }
        public string? Author { get; set; }
    }
}

