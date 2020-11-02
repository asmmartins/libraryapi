using Library.Domain.Shared;
using Library.Domain.Shared.ValueObjects.Addresses;
using System;

namespace Library.Domain.PublicSchools
{
    public partial class PublicSchool : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Inep { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        protected PublicSchool() { }
    }
}