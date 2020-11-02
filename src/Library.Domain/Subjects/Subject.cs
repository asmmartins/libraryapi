using Library.Domain.Shared;
using System;

namespace Library.Domain.Subjects
{
    public partial class Subject : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }        

        protected Subject() { }
    }
}