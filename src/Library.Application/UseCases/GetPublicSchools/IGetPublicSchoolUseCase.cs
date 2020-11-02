using Library.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetPublicSchools
{
    public interface IGetPublicSchoolsUseCase
    {
        Task<IEnumerable<PublicSchoolDto>> Execute();
    }
}