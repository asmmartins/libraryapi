﻿using FluentAssertions;
using FluentValidation;
using Library.Tests.Unit.Shared;
using Xunit;
using BookDomain = Library.Domain.Books;

namespace Library.Tests.Unit.Domain.Books
{
    public class BooksTests
    {
        [Theory]
        [InlineData(null, "'Title' não pode ser nulo.")]
        [InlineData("", "'Title' deve ser informado.")]
        [InlineData("01234567890123456789012345678901234567890", "'Title' deve ser menor ou igual a 40 caracteres. Você digitou 41 caracteres.")]
        public void Shouldnot_CreatBook_WithTitleInvalid(string title, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => BookDomain.Book.Create(title, null, 1, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Publishing Company' não pode ser nulo.")]
        [InlineData("", "'Publishing Company' deve ser informado.")]
        [InlineData("01234567890123456789012345678901234567890", "'Publishing Company' deve ser menor ou igual a 40 caracteres. Você digitou 41 caracteres.")]
        public void Shouldnot_CreatBook_WithPublishingCompanyInvalid(string publishingCompany, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => BookDomain.Book.Create("Livro 1", publishingCompany, 0, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Edition' deve ser informado.")]
        [InlineData(0, "'Edition' deve ser informado.")]        
        public void Shouldnot_CreatBook_WithEditionInvalid(int edition, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => BookDomain.Book.Create("Livro 1", "Casa do Saber", edition, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Publication Year' não pode ser nulo.")]
        [InlineData("", "'Publication Year' deve ser informado.")]
        [InlineData("19254", "'Publication Year' deve ser menor ou igual a 4 caracteres. Você digitou 5 caracteres.")]
        [InlineData("198", "'Publication Year' deve ser maior ou igual a 4 caracteres. Você digitou 3 caracteres.")]
        public void Shouldnot_CreatBook_WithPublicationYearInvalid(string publicationYear, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => BookDomain.Book.Create("Livro 1", "Casa do Saber", 1, publicationYear));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Livro 1", "Casa do Saber", 1, "1990")]
        [InlineData("Livro 52", "Visão de Mundo", 52, "1993")]
        [InlineData("Livro 150", "Tech", 150, "2020")]
        public void Should_CreateBook(string title, string publishingCompany, int edition, string publicationYear)
        {
            var book = BookDomain.Book.Create(title, publishingCompany, edition, publicationYear);

            book.Should().NotBeNull();
            book.Title.Should().Be(title);
            book.PublishingCompany.Should().Be(publishingCompany);
            book.Edition.Should().Be(edition);
            book.PublicationYear.Should().Be(publicationYear);

        }
    }
}
