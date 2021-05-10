using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bookCollection.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookCollection
{
    public interface IBookBackend
    {
        Task<List<BookDBContext.Book>> GetBooks();
        
        Task<BookDBContext.Book> AddBook(BookDBContext.Book book);

        Task<BookDBContext.Book> UpdateBook(BookDBContext.Book book);

        Task<ActionResult<Guid>> DeleteBook(Guid bookId);
    }
}