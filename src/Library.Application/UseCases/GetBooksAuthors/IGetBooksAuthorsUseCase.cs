using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetBooksAuthors
{
    public interface IGetBooksAuthorsUseCase
    {
        Task<IEnumerable<BookAuthorDto>> Execute();
    }
}