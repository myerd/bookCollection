using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bookCollection.Models
{
    public class BookDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=books.db");

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(), Name = "Harry Potter 1", Author = "J.K. Rowling",
                    Description = "Story of wizard"
                },
                new Book
                {
                    Id = Guid.NewGuid(), Name = "Lord of the Rings", Author = "J.R.R Tolkien",
                    Description = "Tale of the ring"
                },
                new Book
                {
                    Id = Guid.NewGuid(), Name = "Supreme Cooking book", Author = "Various",
                    Description = "The book of cooking"
                },
                new Book
                {
                    Id = Guid.NewGuid(), Name = "Random Generator", Author = "Book author",
                    Description = "Just filling database"
                },
            };
            modelBuilder.Entity<Book>().HasData(books);
            base.OnModelCreating(modelBuilder);
        }

        public class Book
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Author { get; set; }

            public string Description { get; set; }

        }
    }
}