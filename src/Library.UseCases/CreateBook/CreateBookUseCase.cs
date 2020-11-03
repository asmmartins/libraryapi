using FluentValidation;
using Library.Application.UseCases.CreateBook;
using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.CreateBook
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IRepository<Book> _BookRepository;        

        public CreateBookUseCase(
            IRepository<Book> BookRepository)
        {
            _BookRepository = BookRepository;            
        }

        public async Task Execute(CreateBookRequest createBookRequest)
        {
            Validate(createBookRequest);

            var subjects = new List<Subject>();
            var authors = new List<Author>();

            var existentBook = await GetBookById(createBookRequest.Id);

            if (existentBook == null)
            {
                var book = Book.Create(createBookRequest.Title, createBookRequest.PublishingCompany, createBookRequest.Edition, createBookRequest.PublicationYear, createBookRequest.Price, subjects, authors);
                await _BookRepository.Save(book);
                return;
            }

            existentBook.Update(createBookRequest.Title, createBookRequest.PublishingCompany, createBookRequest.Edition, createBookRequest.PublicationYear, createBookRequest.Price, subjects, authors);
            await _BookRepository.Save(existentBook);
        }

        private static void Validate(CreateBookRequest createBookRequest)
        {
            if (createBookRequest == null)
                throw new ArgumentNullException("CreateBookRequest");

            var validator = new CreateBookRequestValidator();
            validator.ValidateAndThrow(createBookRequest);
        }    

        private async Task<Book> GetBookById(Guid? id)
        {
            if (!id.HasValue)            
                return null;

            var books = await _BookRepository.GetAll();
            return books?.FirstOrDefault(book => book.Id == id.Value);
        }
    }
}