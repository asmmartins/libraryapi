using AutoMapper;
using Library.Application.UseCases.GetBooks;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Books;
using Library.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UseCases.GetBooks
{
    public class GetBooksUseCase : IGetBooksUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;

        public GetBooksUseCase(
            IMapper mapper,
            IRepository<Book> bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> Execute()
        {
            var books = await _bookRepository.GetAll();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }        
    }
}
