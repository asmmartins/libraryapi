using FluentValidation;
using Library.Application.UseCases.RemoveAuthor;
using Library.Domain.Authors;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.RemoveAuthor
{
    public class RemoveAuthorUseCase : IRemoveAuthorUseCase
    {
        private readonly IRepository<Author> _authorRepository;

        public RemoveAuthorUseCase(
            IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Execute(RemoveAuthorRequest RemoveAuthorRequest)
        {
            Validate(RemoveAuthorRequest);

            var existentAuthor = await GetAuthorById(RemoveAuthorRequest.Id);

            if (existentAuthor == null)
                throw new ArgumentException("Author not found");

            await _authorRepository.Remove(existentAuthor);
        }

        private static void Validate(RemoveAuthorRequest RemoveAuthorRequest)
        {
            if (RemoveAuthorRequest == null)
                throw new ArgumentNullException("RemoveAuthorRequest");

            var validator = new RemoveAuthorRequestValidator();
            validator.ValidateAndThrow(RemoveAuthorRequest);
        }

        private async Task<Author> GetAuthorById(Guid id)
        {
            var authors = await _authorRepository.GetAll();
            return authors?.FirstOrDefault(author => author.Id == id);
        }
    }
}