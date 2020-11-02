using Library.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    internal static class RepositoryDependecyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            /*services.AddDbContext<LibraryDbContext>(opt =>
               opt.UseInMemoryDatabase("LibraryDb"));*/

            services.AddDbContext<LibraryDbContext>(opcoes => opcoes
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Default;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}