using BookStoreApi.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreApi.Repository
{
    public interface IBookStoreRepository
    {
        Task<int> AddNewBookAsync(BookModel book);

        Task DeleteBookAsync(int bookid);

        Task<List<BookModel>> GetAllBooksAsync();

        Task<BookModel> GetBookByIdAsync(int bookid);

        Task UpdateBookAsync(int id, BookModel Book);


    }
}