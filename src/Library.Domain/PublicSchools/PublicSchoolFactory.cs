using FluentValidation;
using Library.Domain.Shared;
using Library.Domain.Shared.ValueObjects.Addresses;
using System;

namespace Library.Domain.PublicSchools
{
    public partial class PublicSchool : IAggregateRoot
    {
        public static PublicSchool Create(string inep, string name, Address address)
        {
            var publicSchool = new PublicSchool()
            {
                Id = Guid.NewGuid(),
                Inep = inep?.Trim(),
                Name = name?.Trim(),
                Address = address
            };

            Validate(publicSchool);

            return publicSchool;
        }

        public PublicSchool Update(string name, Address address)
        {
            Name = name?.Trim();
            Address = address;

            Validate(this);

            return this;
        }

        private static void Validate(PublicSchool publicSchool)
        {
            var validator = new PublicSchoolValidator();
            validator.ValidateAndThrow(publicSchool);
        }
    }
}
