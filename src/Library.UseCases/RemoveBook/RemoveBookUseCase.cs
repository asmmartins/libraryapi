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

        public async Task Execute(RemoveBookRequest RemoveBookRequest)
        {
            Validate(RemoveBookRequest);
            
            var existentBook = await GetBookById(RemoveBookRequest.Id);

            if (existentBook == null)            
                throw new ArgumentException("Book not found");            
            
            await _bookRepository.Remove(existentBook);
        }

        private static void Validate(RemoveBookRequest RemoveBookRequest)
        {
            if (RemoveBookRequest == null)
                throw new ArgumentNullException("RemoveBookRequest");

            var validator = new RemoveBookRequestValidator();
            validator.ValidateAndThrow(RemoveBookRequest);
        }    

        private async Task<Book> GetBookById(Guid id)
        {
            var books = await _bookRepository.GetAll();
            return books?.FirstOrDefault(book => book.Id == id);
        }
    }
}