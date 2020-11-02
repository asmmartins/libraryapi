using Library.Domain.Authors;
using Library.Domain.Shared;
using Library.Domain.Subjects;
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

        public ICollection<Subject> Subjects { get; private set; }

        public ICollection<Author> Authors { get; private set; }

        protected Book() { }
    }
}