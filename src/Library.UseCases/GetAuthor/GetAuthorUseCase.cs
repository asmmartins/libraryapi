using AutoMapper;
using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace Library.UseCases.GetAuthor
{
    public class GetAuthorUseCase : IGetAuthorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Author> _authorRepository;

        public GetAuthorUseCase(
            IMapper mapper,
            IRepository<Author> authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<AuthorDto> Execute(Guid id)
        {
            var Author = await _authorRepository.GetById(id);
            return _mapper.Map<AuthorDto>(Author);
        }
    }
}
