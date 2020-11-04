using Library.Application.UseCases.GetBooksAuthors;
using Library.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UseCases.GetBooksAuthors
{
    public class GetBooksAuthorsUseCase : IGetBooksAuthorsUseCase
    {
        private readonly IDataAccess _dataAccess;
        
        public GetBooksAuthorsUseCase(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<BookAuthorDto>> Execute()
        {
            return _dataAccess.GetAll<BookAuthorDto>("BooksAuthors");
        }
    }
}

