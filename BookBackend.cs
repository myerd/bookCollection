using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookCollection.Models;

namespace bookCollection
{
    
    public class BookBackend : IBookBackend
    {
        private readonly BookDBContext _bookDbContext = new BookDBContext();

        public Task<List<BookDBContext.Book>> GetBooks()
        {
            var books = _bookDbContext.Books.ToList();
            return Task.FromResult(books);
        }

        public Task<BookDBContext.Book> AddBook(BookDBContext.Book book)
        {
            var bk = new BookDBContext.Book();
            bk.Id = new Guid();
            bk.Name = book.Name;
            bk.Author = book.Author;
            bk.Description = book.Description;

            _bookDbContext.Books.Add(bk);
            _bookDbContext.SaveChanges();

            return Task.FromResult(bk);
        }

        public Task<BookDBContext.Book> UpdateBook(BookDBContext.Book book)
        {
            var bk = _bookDbContext.Books.Find(book.Id);
            bk.Name = book.Name;
            bk.Author = book.Author;
            bk.Description = book.Description;
            _bookDbContext.Books.Update(bk);
            _bookDbContext.SaveChanges();

            return Task.FromResult(bk);
        }

        public Task<Guid> DeleteBook(Guid bookId)
        {
            var book = _bookDbContext.Books.FirstOrDefault(t => t.Id == bookId);
            if (book != null) {
                _bookDbContext.Books.Remove(book);
                _bookDbContext.SaveChanges();
            }

            return Task.FromResult(bookId);
        }
    }
}