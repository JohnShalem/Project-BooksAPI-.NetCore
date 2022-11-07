using BookStoreApi.Model;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookStoreRepository _storeRepository;

        public BooksController(IBookStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        //GET API
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _storeRepository.GetAllBooksAsync();
            return Ok(books);
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _storeRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else { return Ok(book); }          
        }

        //POST API 
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel book)
        {
            var id = await _storeRepository.AddNewBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = id, Controller = "Books" }, book);
        }

        //PUT API 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel book , [FromRoute] int id)
        {
            await _storeRepository.UpdateBookAsync(id, book);
            return Ok();
        }


        //DELETE API 
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _storeRepository.DeleteBookAsync(id);
            return Ok();
        }



    }
}
