using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Groups;
using Library.Domain.PublicSchools;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using Library.Repository.Authors;
using Library.Repository.Books;
using Library.Repository.Groups;
using Library.Repository.PublicSchools;
using Library.Repository.Shared;
using Library.Repository.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    internal static class DbContextDependecyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<PublicSchoolDbContext>();
            services.AddScoped<IRepository<PublicSchool>, PublicSchoolRepository>();

            services.AddSingleton<GroupDbContext>();
            services.AddScoped<IRepository<Group>, GroupRepository>();

            services.AddScoped<IRepository<Author>, AuthorRepository>();

            services.AddScoped<IRepository<Subject>, SubjectRepository>();

            services.AddScoped<IRepository<Book>, BookRepository>();
        }
    }
}