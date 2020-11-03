using Library.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetAuthors
{
    public interface IGetAuthorsUseCase
    {
        Task<IEnumerable<AuthorDto>> Execute();
    }
}