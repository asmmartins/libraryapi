using FluentAssertions;
using FluentValidation;
using Library.Tests.Unit.Shared;
using Xunit;
using AuthorDomain = Library.Domain.Authors;

namespace Library.Tests.Unit.Domain.Authors
{
    public class AuthorsTests
    {
        [Theory]
        [InlineData(null, "'Name' não pode ser nulo.")]
        [InlineData("", "'Name' deve ser informado.")]
        [InlineData("01234567890123456789012345678901234567890", "'Name' deve ser menor ou igual a 40 caracteres. Você digitou 41 caracteres.")]
        public void Shouldnot_CreatAuthor_WithNameInvalid(string name, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => AuthorDomain.Author.Create(name));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Ana Carolina Silva Martins")]
        [InlineData("Caio Paes")]
        public void Should_CreateAuthor(string name)
        {
            var author = AuthorDomain.Author.Create(name);

            author.Should().NotBeNull();
            author.Name.Should().Be(name);
        }
    }
}
