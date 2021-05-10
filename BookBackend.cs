using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookCollection
{
    public class BookBackend : IBookBackend
    {
        private readonly BookDBContext _bookDbContext = new BookDBContext();

        public async Task<List<BookDBContext.Book>> GetBooks()
        {
            return await _bookDbContext.Books.ToListAsync();
        }

        public async Task<BookDBContext.Book> AddBook(BookDBContext.Book book)
        {
            var bk = new BookDBContext.Book
            {
                Id = new Guid(),
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
            };

            _bookDbContext.Books.Add(bk);
            await _bookDbContext.SaveChangesAsync();

            return bk;
        }

        public async Task<BookDBContext.Book> UpdateBook(BookDBContext.Book book)
        {
            var bk = _bookDbContext.Books.Find(book.Id);
            bk.Name = book.Name;
            bk.Author = book.Author;
            bk.Description = book.Description;
            
            _bookDbContext.Books.Update(bk);
            await _bookDbContext.SaveChangesAsync();

            return bk;
        }

        public async Task<ActionResult<Guid>> DeleteBook(Guid bookId)
        {
            var book = _bookDbContext.Books.FirstOrDefault(t => t.Id == bookId);
            if (book == null) {
                return new NotFoundResult();
            }

            _bookDbContext.Books.Remove(book);
            await _bookDbContext.SaveChangesAsync();
            return bookId;
        }
    }
}