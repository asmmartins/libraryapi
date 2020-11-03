using Library.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetAuthor
{
    public interface IGetAuthorUseCase
    {
        Task<AuthorDto> Execute(Guid id);
    }
}