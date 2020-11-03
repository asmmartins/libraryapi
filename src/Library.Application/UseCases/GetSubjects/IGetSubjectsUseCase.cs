using Library.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetSubjects
{
    public interface IGetSubjectsUseCase
    {
        Task<IEnumerable<SubjectDto>> Execute();
    }
}