using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bookCollection.Models;
using Microsoft.AspNetCore.Mvc;


namespace bookCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController
    {
        private readonly IBookBackend _backend;

        public BookController(IBookBackend backend)
        {
            _backend = backend;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<BookDBContext.Book>), 200)]
        public async Task<List<BookDBContext.Book>> GetBooks()
        {
            return await _backend.GetBooks();
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookDBContext.Book), 200)]
        public async Task<IActionResult> CreateBook(
            [FromBody] BookDBContext.Book book)
        {
            var bk = await _backend.AddBook(book);
            return new StatusCodeResult(200);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BookDBContext.Book), 200)]
        public async Task<IActionResult> UpdateBook(
            [FromBody] BookDBContext.Book book)
        {
            var bk = await _backend.UpdateBook(book);
            return new StatusCodeResult(200);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BookDBContext.Book), 200)]
        public async Task<Guid> DeleteBook(
            [FromBody] Guid bookId)
        {
            return await _backend.DeleteBook(bookId);
        }

    }
}