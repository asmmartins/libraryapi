using FluentValidation;
using Library.Application.UseCases.RemoveSubject;
using Library.Domain.Subjects;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.RemoveSubject
{
    public class RemoveSubjectUseCase : IRemoveSubjectUseCase
    {
        private readonly IRepository<Subject> _SubjectRepository;        

        public RemoveSubjectUseCase(
            IRepository<Subject> SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;            
        }

        public async Task Execute(RemoveSubjectRequest RemoveSubjectRequest)
        {
            Validate(RemoveSubjectRequest);
            
            var existentSubject = await GetSubjectById(RemoveSubjectRequest.Id);

            if (existentSubject == null)            
                throw new ArgumentException("Subject not found");            
            
            await _SubjectRepository.Remove(existentSubject);
        }

        private static void Validate(RemoveSubjectRequest RemoveSubjectRequest)
        {
            if (RemoveSubjectRequest == null)
                throw new ArgumentNullException("RemoveSubjectRequest");

            var validator = new RemoveSubjectRequestValidator();
            validator.ValidateAndThrow(RemoveSubjectRequest);
        }    

        private async Task<Subject> GetSubjectById(Guid id)
        {
            var Subjects = await _SubjectRepository.GetAll();
            return Subjects?.FirstOrDefault(Subject => Subject.Id == id);
        }
    }
}