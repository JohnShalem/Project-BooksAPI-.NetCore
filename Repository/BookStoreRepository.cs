using BookStoreApi.Model;
using BookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repository
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly BookstoreContext _bookstore;
    

        public BookStoreRepository(BookstoreContext bookstore)
        {
            this._bookstore = bookstore;
            
        }


        //Get all books
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = _bookstore.BookStores.Select(x => new BookModel()
            {
                Id = x.Id,
                Author = x.Author,
                BookName = x.BookName,
            });
            return await records.ToListAsync();
        }

        //Get book by Id
        public async Task<BookModel> GetBookByIdAsync(int bookid)
        {
            var record = await _bookstore.BookStores.Where(x => x.Id == bookid).Select(x => new BookModel()
            {
                Id = x.Id,
                Author = x.Author,
                BookName = x.BookName,
            }).FirstOrDefaultAsync();

            return record;

        }

        //Post a new Book
        public async Task<int> AddNewBookAsync(BookModel book)
        {
            var Book = new BookStore()
            {
                Author = book.Author,
                Id = book.Id,
                BookName = book.BookName
            };

            _bookstore.BookStores.Add(Book);
            await _bookstore.SaveChangesAsync();

            return Book.Id;
        }

        //Put a book 'Update all properties in a book'
        public async Task UpdateBookAsync(int id,BookModel Book)
        {
            var book = new BookStore()
            {
                Author = Book.Author,
                Id = Book.Id,
                BookName = Book.BookName
            };

            _bookstore.BookStores.Update(book);
            await _bookstore.SaveChangesAsync();
        }

        //Delete a Book
        public async Task DeleteBookAsync(int bookid)
        {
            var book = new BookStore() { Id = bookid };
            _bookstore.Remove(book);
            await _bookstore.SaveChangesAsync();
        }

        




    }
}
