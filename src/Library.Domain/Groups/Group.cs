
using Library.Domain.PublicSchools;
using Library.Domain.Shared;
using System;

namespace Library.Domain.Groups
{
    public partial class Group : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public PublicSchool PublicSchool { get; private set; }

        protected Group() { }
    }
}