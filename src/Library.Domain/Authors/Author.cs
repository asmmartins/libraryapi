using Library.Domain.Shared;
using System;

namespace Library.Domain.Authors
{
    public partial class Author : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }        

        protected Author() { }
    }
}