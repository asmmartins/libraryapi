using Microsoft.Extensions.DependencyInjection;
using Library.Domain.Groups;
using Library.Domain.PublicSchools;
using Library.Domain.Shared;
using Library.Repository.Groups;
using Library.Repository.PublicSchools;
using Library.Repository.Shared;

namespace Library.Infra.Ioc
{
    internal static class DbContextDependecyInjection
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddSingleton<PublicSchoolDbContext>();
            services.AddScoped<IRepository<PublicSchool>, PublicSchoolRepository>();

            services.AddSingleton<GroupDbContext>();
            services.AddScoped<IRepository<Group>, GroupRepository>();
        }
    }
}