using Library.Application.UseCases.CreateAuthor;
using Library.Application.UseCases.CreateBook;
using Library.Application.UseCases.CreateSubject;
using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.GetAuthors;
using Library.Application.UseCases.GetBook;
using Library.Application.UseCases.GetBooks;
using Library.Application.UseCases.GetBooksAuthors;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.GetSubjects;
using Library.Application.UseCases.RemoveAuthor;
using Library.Application.UseCases.RemoveBook;
using Library.Application.UseCases.RemoveSubject;
using Library.UseCases.CreateAuthor;
using Library.UseCases.CreateBook;
using Library.UseCases.CreateSubject;
using Library.UseCases.GetAuthor;
using Library.UseCases.GetAuthors;
using Library.UseCases.GetBook;
using Library.UseCases.GetBooks;
using Library.UseCases.GetBooksAuthors;
using Library.UseCases.GetSubject;
using Library.UseCases.GetSubjects;
using Library.UseCases.RemoveAuthor;
using Library.UseCases.RemoveBook;
using Library.UseCases.RemoveSubject;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    internal static class UseCasesDependecyInjection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateAuthorUseCase, CreateAuthorUseCase>();
            services.AddTransient<IGetAuthorUseCase, GetAuthorUseCase>();
            services.AddTransient<IGetAuthorsUseCase, GetAuthorsUseCase>();
            services.AddTransient<IRemoveAuthorUseCase, RemoveAuthorUseCase>();

            services.AddTransient<ICreateSubjectUseCase, CreateSubjectUseCase>();
            services.AddTransient<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddTransient<IGetSubjectsUseCase, GetSubjectsUseCase>();
            services.AddTransient<IRemoveSubjectUseCase, RemoveSubjectUseCase>();

            services.AddTransient<ICreateBookUseCase, CreateBookUseCase>();
            services.AddTransient<IGetBookUseCase, GetBookUseCase>();
            services.AddTransient<IGetBooksUseCase, GetBooksUseCase>();
            services.AddTransient<IRemoveBookUseCase, RemoveBookUseCase>();

            services.AddTransient<IGetBooksAuthorsUseCase, GetBooksAuthorsUseCase>();
        }
    }
}
