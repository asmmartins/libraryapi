using FluentValidation;
using Library.Domain.Authors;
using Library.Domain.BookAuthors;
using Library.Domain.BookSubjects;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
using System.Collections.Generic;

namespace Library.Domain.Books
{
    public partial class Book : IAggregateRoot
    {
        public static Book Create(string title, string publishingCompany, int edition, string publicationYear, decimal price, List<Subject> subjects, List<Author> authors)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = title?.Trim(),
                PublishingCompany = publishingCompany?.Trim(),
                Edition = edition,
                PublicationYear = publicationYear?.Trim(),
                Price = price,
            };

            book.BookSubjects = BookSubject.Create(book, subjects);
            book.BookAuthors = BookAuthor.Create(book, authors);

            Validate(book);

            return book;
        }


        public void Update(string title, string publishingCompany, int edition, string publicationYear, decimal price, List<Subject> subjects, List<Author> authors)
        {

            Title = title?.Trim();
            PublishingCompany = publishingCompany?.Trim();
            Edition = edition;
            PublicationYear = publicationYear?.Trim();
            Price = price;

            BookSubjects = BookSubject.Create(this, subjects);
            BookAuthors = BookAuthor.Create(this, authors);

            Validate(this);
        }

        private static void Validate(Book book)
        {
            var validator = new BookValidator();
            validator.ValidateAndThrow(book);
        }
    }
}
