using FluentAssertions;
using FluentValidation;
using Library.Application.UseCases.CreateSubject;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.GetSubjects;
using Library.Application.UseCases.RemoveSubject;
using Library.Tests.Integration.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.UseCases
{
    public class CreateSubjectUseCaseTests
    {        
        private readonly ICreateSubjectUseCase _createSubjectUseCase;
        private readonly IGetSubjectUseCase _getSubjectUseCase;
        private readonly IGetSubjectsUseCase _getSubjectsUseCase;
        private readonly IRemoveSubjectUseCase _removeSubjectUseCase;

        public CreateSubjectUseCaseTests(            
            ICreateSubjectUseCase createSubjectUseCase,
            IGetSubjectUseCase getSubjectUseCase,
            IGetSubjectsUseCase getSubjectsUseCase,
            IRemoveSubjectUseCase removeSubjectUseCase)
        {            
            _createSubjectUseCase = createSubjectUseCase;
            _getSubjectUseCase = getSubjectUseCase;
            _getSubjectsUseCase = getSubjectsUseCase;
            _removeSubjectUseCase = removeSubjectUseCase;
        }

        [Theory]        
        [InlineData("Ficção Ciêntifica")]
        [InlineData("Religião")]
        public async Task Should_CreateSubjectUseCase(string description)
        {
            CreateSubjectRequest createSubjectRequest = new CreateSubjectRequest()
            {                
                Description = description
            };

            await _createSubjectUseCase.Execute(createSubjectRequest);            

            var subjects = await _getSubjectsUseCase.Execute();
            subjects.Should().NotBeNull();
            subjects.Should().OnlyHaveUniqueItems();

            var subject = subjects.FirstOrDefault(x => x.Description.ToLower() == createSubjectRequest.Description.ToLower());

            var existentSubject = await _getSubjectUseCase.Execute(subject.Id);
            existentSubject.Should().NotBeNull();
            existentSubject.Should().BeEquivalentTo(subject);

            await _removeSubjectUseCase.Execute(new RemoveSubjectRequest() { Id = subject.Id });
            existentSubject = await _getSubjectUseCase.Execute(subject.Id);
            existentSubject.Should().BeNull();
        }

        [Fact]
        public async Task Shouldnot_CreateSubjectUseCase_WithRequestNull()
        {
            ArgumentNullException ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _createSubjectUseCase.Execute(null));
            ex.Should().NotBeNull();
            ex.Message.Should().Be("Value cannot be null. (Parameter 'CreateSubjectRequest')");
        }

        [Fact]
        public async Task Shouldnot_CreateSubjectUseCase_WithDescriptionNull()
        {
            var request = new CreateSubjectRequest() { Description = null };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createSubjectUseCase.Execute(request));
            ex.AssertErrorMessage("'Description' não pode ser nulo.");
        }
    }
}