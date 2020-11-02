using FluentValidation;
using Library.Domain.Shared;
using System;

namespace Library.Domain.Subjects
{
    public partial class Subject : IAggregateRoot
    {
        public static Subject Create(string name)
        {
            var subject = new Subject()
            {
                Id = Guid.NewGuid(),
                Name = name?.Trim(),                
            };

            Validate(subject);

            return subject;
        }       

        private static void Validate(Subject subject)
        {
            var validator = new SubjectValidator();
            validator.ValidateAndThrow(subject);
        }
    }
}
