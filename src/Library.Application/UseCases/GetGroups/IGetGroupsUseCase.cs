using Library.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetGroups
{
    public interface IGetGroupsUseCase
    {
        Task<IEnumerable<GroupDto>> Execute(string inep);
    }
}