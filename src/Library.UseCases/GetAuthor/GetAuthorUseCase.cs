using AutoMapper;
using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System;
using System.Linq;
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
            var Author = await GetAuthorById(id);
            return _mapper.Map<AuthorDto>(Author);
        }

        private async Task<Author> GetAuthorById(Guid id)
        {
            var authors = await _authorRepository.GetAll();
            return authors?.FirstOrDefault(ps => ps.Id == id);
        }
    }
}
