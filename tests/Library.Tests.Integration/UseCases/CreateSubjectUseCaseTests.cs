using FluentAssertions;
using FluentValidation;
using Library.Application.UseCases.CreateSubject;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.GetSubjects;
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


        public CreateSubjectUseCaseTests(            
            ICreateSubjectUseCase createSubjectUseCase,
            IGetSubjectUseCase getSubjectUseCase,
            IGetSubjectsUseCase getSubjectsUseCase)
        {            
            _createSubjectUseCase = createSubjectUseCase;
            _getSubjectUseCase = getSubjectUseCase;
            _getSubjectsUseCase = getSubjectsUseCase;
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

            var Subjects = await _getSubjectsUseCase.Execute();
            Subjects.Should().NotBeNull();
            Subjects.Should().OnlyHaveUniqueItems();

            var Subject = Subjects.First();
            var existentSubject = await _getSubjectUseCase.Execute(Subject.Id);
            existentSubject.Should().NotBeNull();
            existentSubject.Should().BeEquivalentTo(Subject);
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