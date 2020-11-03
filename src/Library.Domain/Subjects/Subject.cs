using Library.Domain.BookSubjects;
using Library.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Library.Domain.Subjects
{
    public partial class Subject : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }

        public List<BookSubject> BookSubjects { get; private set; }

        protected Subject() { }
    }
}