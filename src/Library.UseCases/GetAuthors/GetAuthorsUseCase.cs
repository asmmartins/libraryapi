using AutoMapper;
using Library.Application.UseCases.GetAuthors;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UseCases.GetAuthors
{
    public class GetAuthorsUseCase : IGetAuthorsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Author> _authorRepository;

        public GetAuthorsUseCase(
            IMapper mapper,
            IRepository<Author> authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorDto>> Execute()
        {
            var authors = await _authorRepository.GetAll();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }
    }
}
