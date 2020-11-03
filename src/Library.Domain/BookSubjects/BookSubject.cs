using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;

namespace Library.Domain.BookSubjects
{
    public partial class BookSubject : IAggregateRoot
    {
        public Guid BookId { get; private set; }
        public Book Book { get; private set; }

        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; }

        protected BookSubject() { }
    }
}