using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using System.Collections.Generic;

namespace Library.Domain.BookAuthors
{
    public partial class BookAuthor : IAggregateRoot
    {
        public static List<BookAuthor> Create(Book book, List<Author> authors)
        {
            var booksAuthors = new List<BookAuthor>();
            foreach (var author in authors)
            {
                booksAuthors.Add(new BookAuthor()
                {
                    BookId = book.Id,
                    Book = book,
                    Author = author,
                    AuthorId = author.Id
                });
            }
            return booksAuthors;
        }
    }
}
