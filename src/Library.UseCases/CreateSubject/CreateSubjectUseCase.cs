using FluentValidation;
using Library.Application.UseCases.CreateSubject;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.CreateSubject
{
    public class CreateSubjectUseCase : ICreateSubjectUseCase
    {
        private readonly IRepository<Subject> _subjectRepository;

        public CreateSubjectUseCase(
            IRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task Execute(CreateSubjectRequest createSubjectRequest)
        {
            Validate(createSubjectRequest);

            var existentSubject = await GetSubjectByName(createSubjectRequest.Description);

            if (existentSubject == null)
            {
                var subject = Subject.Create(createSubjectRequest.Description);
                await _subjectRepository.Save(subject);
                return;
            }

            existentSubject.Update(createSubjectRequest.Description);
            await _subjectRepository.Save(existentSubject);
        }

        private static void Validate(CreateSubjectRequest createSubjectRequest)
        {
            if (createSubjectRequest == null)
                throw new ArgumentNullException("CreateSubjectRequest");

            var validator = new CreateSubjectRequestValidator();
            validator.ValidateAndThrow(createSubjectRequest);
        }

        private async Task<Subject> GetSubjectByName(string name)
        {
            var subjects = await _subjectRepository.GetAll();
            return subjects?.FirstOrDefault(subject => subject.Description.ToLower() == name?.Trim().ToLower());
        }
    }
}