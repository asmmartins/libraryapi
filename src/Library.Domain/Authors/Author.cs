using Library.Domain.BookAuthors;
using Library.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Library.Domain.Authors
{
    public partial class Author : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public List<BookAuthor> BookAuthors { get; private set; }

        protected Author() { }
    }
}