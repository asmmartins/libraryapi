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
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Author> _authorRepository;

        public CreateBookUseCase(
            IRepository<Book> bookRepository,
            IRepository<Subject> subjectRepository,
            IRepository<Author> authorRepository)
        {
            _bookRepository = bookRepository;
            _subjectRepository = subjectRepository;
            _authorRepository = authorRepository;
        }

        public async Task Execute(CreateBookRequest createBookRequest)
        {
            Validate(createBookRequest);

            var subjects = await GetSubjects(createBookRequest.Subjects);
            var authors = await GetAuthors(createBookRequest.Authors);

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

        private async Task<List<Subject>> GetSubjects(List<Guid> subjectIds)
        {
            var subjects = new List<Subject>();

            if (!((subjectIds != null) && subjectIds.Any()))
                return subjects;

            foreach (var subjectId in subjectIds)
            {
                var subject = await _subjectRepository.GetById(subjectId);
                if (subject != null)
                    subjects.Add(subject);
            }

            return subjects;
        }

        private async Task<List<Author>> GetAuthors(List<Guid> authorIds)
        {
            var authors = new List<Author>();

            if (!((authorIds != null) && authorIds.Any()))
                return authors;

            foreach (var authorId in authorIds)
            {
                var author = await _authorRepository.GetById(authorId);
                if (author != null)
                    authors.Add(author);
            }

            return authors;
        }
    }
}
