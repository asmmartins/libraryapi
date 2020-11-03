using FluentAssertions;
using FluentValidation;
using Library.Tests.Unit.Shared;
using Xunit;
using SubjectDomain = Library.Domain.Subjects;

namespace Library.Tests.Unit.Domain.Subjects
{
    public class SubjectsTests
    {
        [Theory]
        [InlineData(null, "'Description' não pode ser nulo.")]
        [InlineData("", "'Description' deve ser informado.")]
        [InlineData("012345678901234567890", "'Description' deve ser menor ou igual a 20 caracteres. Você digitou 21 caracteres.")]
        public void Shouldnot_CreatSubject_WithNameInvalid(string description, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => SubjectDomain.Subject.Create(description));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Romance")]
        [InlineData("Computação")]
        [InlineData("Poesia")]
        public void Should_CreateSubject(string description)
        {
            var subject = SubjectDomain.Subject.Create(description);

            subject.Should().NotBeNull();
            subject.Description.Should().Be(description);
        }
    }
}
