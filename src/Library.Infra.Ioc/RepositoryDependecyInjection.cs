using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using Library.Repository.Authors;
using Library.Repository.Books;
using Library.Repository.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    internal static class DbContextDependecyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Author>, AuthorRepository>();
            services.AddScoped<IRepository<Subject>, SubjectRepository>();
            services.AddScoped<IRepository<Book>, BookRepository>();
        }
    }
}