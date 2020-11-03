using FluentValidation;
using Library.Application.UseCases.CreateBook;
using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UseCases.CreateBook
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IRepository<Book> _bookRepository;

        public CreateBookUseCase(
            IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
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
                await _bookRepository.Save(book);
                return;
            }

            existentBook.Update(createBookRequest.Title, createBookRequest.PublishingCompany, createBookRequest.Edition, createBookRequest.PublicationYear, createBookRequest.Price, subjects, authors);
            await _bookRepository.Save(existentBook);
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

            return await _bookRepository.GetById(id.Value);
        }
    }
}