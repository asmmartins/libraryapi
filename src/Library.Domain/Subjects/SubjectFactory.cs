using FluentValidation;
using Library.Domain.Shared;
using System;

namespace Library.Domain.Subjects
{
    public partial class Subject : IAggregateRoot
    {
        public static Subject Create(string description)
        {
            var subject = new Subject()
            {
                Id = Guid.NewGuid(),
                Description = description?.Trim(),                
            };

            Validate(subject);

            return subject;
        }

        public void Update(string description)
        {
            Description = description?.Trim();
            Validate(this);
        }

        private static void Validate(Subject subject)
        {
            var validator = new SubjectValidator();
            validator.ValidateAndThrow(subject);
        }
    }
}
