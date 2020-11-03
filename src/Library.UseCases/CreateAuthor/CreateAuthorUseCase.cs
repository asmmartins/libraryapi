using FluentValidation;
using Library.Application.UseCases.CreateAuthor;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System;
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

            var existentAuthor = await GetAuthorById(createAuthorRequest.Id);

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

        private async Task<Author> GetAuthorById(Guid? id)
        {
            if (!id.HasValue)
                return null;

            return await _authorRepository.GetById(id.Value);
        }
    }
}
