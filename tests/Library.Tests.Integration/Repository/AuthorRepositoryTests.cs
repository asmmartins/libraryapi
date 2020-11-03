using FluentAssertions;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.Repository
{
    public class AuthorRepositoryTests
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorRepositoryTests(IRepository<Author> AuthorRepository)
        {
            _authorRepository = AuthorRepository;
        }

        [Theory]
        [InlineData("Ana Carolina Silva Martins")]
        [InlineData("Caio Paes")]
        public async Task Should_SaveAndGetAllAuthorInDbContext(string name)
        {
            var author = Author.Create(name);

            await _authorRepository.Save(author);
            var authors = await _authorRepository.GetAll();

            authors.Should().NotBeNull();
            authors.Should().OnlyHaveUniqueItems();

            await _authorRepository.Save(author);

            authors = await _authorRepository.GetAll();

            var existent = authors.FirstOrDefault(x => x.Id == author.Id);
            existent.Should().Be(author);

            var existents = authors.Where(x => x.Id == author.Id).ToList();
            existents.Count.Should().Be(1);
        }
    }
}
