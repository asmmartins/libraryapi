using FluentAssertions;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.Repository
{
    public class SubjectRepositoryTests
    {
        private readonly IRepository<Subject> _subjectRepository;

        public SubjectRepositoryTests(IRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [Theory]
        [InlineData("Romance")]
        [InlineData("Poesia")]
        [InlineData("Drama")]
        public async Task Should_SaveAndGetAllSubjectInDbContext(string name)
        {
            var subject = Subject.Create(name);

            await _subjectRepository.Save(subject);
            var subjects = await _subjectRepository.GetAll();

            subjects.Should().NotBeNull();
            subjects.Should().OnlyHaveUniqueItems();

            await _subjectRepository.Save(subject);

            subjects = await _subjectRepository.GetAll();

            var existent = subjects.FirstOrDefault(x => x.Id == subject.Id);
            existent.Should().Be(subject);

            var existents = subjects.Where(x => x.Id == subject.Id).ToList();
            existents.Count.Should().Be(1);

            await _subjectRepository.Remove(subject);

            subjects = await _subjectRepository.GetAll();

            existent = subjects.FirstOrDefault(x => x.Id == subject.Id);
            existent.Should().BeNull();

            existents = subjects.Where(x => x.Id == subject.Id).ToList();
            existents.Count.Should().Be(0);
        }
    }
}
