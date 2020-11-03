using FluentValidation;
using Library.Domain.Shared;
using System;

namespace Library.Domain.Authors
{
    public partial class Author : IAggregateRoot
    {
        public static Author Create(string name)
        {
            var author = new Author()
            {
                Id = Guid.NewGuid(),
                Name = name?.Trim(),
            };

            Validate(author);

            return author;
        }

        public void Update(string name)
        {
            Name = name?.Trim();
            Validate(this);
        }

        private static void Validate(Author author)
        {
            var validator = new AuthorValidator();
            validator.ValidateAndThrow(author);
        }
    }
}
