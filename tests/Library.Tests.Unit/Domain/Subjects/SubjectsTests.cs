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
        [InlineData(null, "'Name' não pode ser nulo.")]
        [InlineData("", "'Name' deve ser informado.")]
        [InlineData("012345678901234567890", "'Name' deve ser menor ou igual a 20 caracteres. Você digitou 21 caracteres.")]
        public void Shouldnot_CreatSubject_WithNameInvalid(string name, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => SubjectDomain.Subject.Create(name));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Romance")]
        [InlineData("Computação")]
        public void Should_CreateSubject(string name)
        {
            var subject = SubjectDomain.Subject.Create(name);

            subject.Should().NotBeNull();
            subject.Name.Should().Be(name);
        }
    }
}
