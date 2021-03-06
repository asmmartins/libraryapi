﻿using AutoMapper;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.BookAuthors;
using Library.Domain.Books;
using Library.Domain.BookSubjects;
using Library.Domain.Shared.ValueObjects.Addresses;
using Library.Domain.Subjects;

namespace Library.Infra.Ioc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateAddressMap();
            CreateAuthorMap();
            CreateSubjectMap();
            CreateBookAuthorMap();
            CreateBookSubjectMap();
            CreateBookMap();            
        }

        private void CreateAddressMap()
        {
            CreateMap<Address, AddressDto>();
        }

        private void CreateAuthorMap()
        {
            CreateMap<Author, AuthorDto>();
        }

        private void CreateSubjectMap()
        {
            CreateMap<Subject, SubjectDto>();
        }

        private void CreateBookMap()
        {
            CreateMap<Book, BookDto>();                               
        }

        private void CreateBookAuthorMap()
        {
            CreateMap<BookAuthor, BookAuthorDto>();
        }

        private void CreateBookSubjectMap()
        {
            CreateMap<BookSubject, BookSubjectDto>();
        }
    }
}
