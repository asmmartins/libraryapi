﻿using Library.Domain.BookAuthors;
using Library.Domain.BookSubjects;
using Library.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Library.Domain.Books
{
    public partial class Book : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string PublishingCompany { get; private set; }
        public int Edition { get; private set; }
        public string PublicationYear { get; private set; }
        public decimal Price { get; private set; }

        public List<BookAuthor> BookAuthors { get; private set; }

        public List<BookSubject> BookSubjects { get; private set; }

        protected Book() { }
    }
}