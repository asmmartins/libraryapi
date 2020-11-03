using Library.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace Library.Application.UseCases.GetBook
{
    public interface IGetBookUseCase
    {
        Task<BookDto> Execute(Guid id);
    }
}