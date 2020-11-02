﻿using FluentValidation;
using Library.Domain.Authors;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
using System.Collections.Generic;

namespace Library.Domain.Books
{
    public partial class Book : IAggregateRoot
    {
        public static Book Create(string title, string publishingCompany, int edition, string publicationYear)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = title?.Trim(), 
                PublishingCompany = publishingCompany?.Trim(),
                Edition = edition,
                PublicationYear = publicationYear?.Trim()
            };

            Validate(book);

            return book;
        }       

        private static void Validate(Book book)
        {
            var validator = new BookValidator();
            validator.ValidateAndThrow(book);
        }
    }
}
