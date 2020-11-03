using Library.Application.UseCases.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetBooks
{
    public interface IGetBooksUseCase
    {
        Task<IEnumerable<BookDto>> Execute();
    }
}