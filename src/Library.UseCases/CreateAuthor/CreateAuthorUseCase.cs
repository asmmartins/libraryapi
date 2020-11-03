using FluentValidation;
using Library.Application.UseCases.CreateAuthor;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.CreateAuthor
{
    public class CreateAuthorUseCase : ICreateAuthorUseCase
    {
        private readonly IRepository<Author> _authorRepository;        

        public CreateAuthorUseCase(
            IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;            
        }

        public async Task Execute(CreateAuthorRequest createAuthorRequest)
        {
            Validate(createAuthorRequest);
            
            var existentAuthor = await GetAuthorByName(createAuthorRequest.Name);

            if (existentAuthor == null)
            {
                var author = Author.Create(createAuthorRequest.Name);
                await _authorRepository.Save(author);
                return;
            }

            existentAuthor.Update(createAuthorRequest.Name);
            await _authorRepository.Save(existentAuthor);
        }

        private static void Validate(CreateAuthorRequest createAuthorRequest)
        {
            if (createAuthorRequest == null)
                throw new ArgumentNullException("CreateAuthorRequest");

            var validator = new CreateAuthorRequestValidator();
            validator.ValidateAndThrow(createAuthorRequest);
        }    

        private async Task<Author> GetAuthorByName(string name)
        {
            var authors = await _authorRepository.GetAll();
            return authors?.FirstOrDefault(Author => Author.Name.ToLower() == name?.Trim().ToLower());
        }
    }
}