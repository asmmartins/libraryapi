using Library.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    internal static class DbContextDependecyInjection
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddDbContext<LibraryDbContext>(opt =>
               opt.UseInMemoryDatabase("LibraryDb"));*/

            services.AddDbContext<LibraryDbContext>(opcoes => opcoes
                .UseSqlServer(configuration.GetConnectionString("LibraryDbContext")));
        }
    }
}