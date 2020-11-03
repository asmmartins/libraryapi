using AutoMapper;
using Library.Application.UseCases.GetBook;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Books;
using Library.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace Library.UseCases.GetBook
{
    public class GetBookUseCase : IGetBookUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;

        public GetBookUseCase(
            IMapper mapper,
            IRepository<Book> bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Execute(Guid id)
        {
            var book = await _bookRepository.GetById(id);
            return _mapper.Map<BookDto>(book);
        }
    }
}
