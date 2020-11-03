using Library.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetSubject
{
    public interface IGetSubjectUseCase
    {
        Task<SubjectDto> Execute(Guid id);
    }
}