using Library.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetGroup
{
    public interface IGetGroupUseCase
    {
        Task<GroupDto> Execute(Guid id);
    }
}