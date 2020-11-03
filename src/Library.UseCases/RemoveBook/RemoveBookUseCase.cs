using FluentValidation;
using Library.Application.UseCases.RemoveBook;
using Library.Domain.Books;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.RemoveBook
{
    public class RemoveBookUseCase : IRemoveBookUseCase
    {
        private readonly IRepository<Book> _bookRepository;

        public RemoveBookUseCase(
            IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Execute(RemoveBookRequest removeBookRequest)
        {
            Validate(removeBookRequest);

            var existentBook = await GetBookById(removeBookRequest.Id);

            if (existentBook == null)
                throw new ArgumentException("Book not found");

            await _bookRepository.Remove(existentBook);
        }

        private static void Validate(RemoveBookRequest removeBookRequest)
        {
            if (removeBookRequest == null)
                throw new ArgumentNullException("RemoveBookRequest");

            var validator = new RemoveBookRequestValidator();
            validator.ValidateAndThrow(removeBookRequest);
        }

        private async Task<Book> GetBookById(Guid id)
        {
            var books = await _bookRepository.GetAll();
            return books?.FirstOrDefault(book => book.Id == id);
        }
    }
}