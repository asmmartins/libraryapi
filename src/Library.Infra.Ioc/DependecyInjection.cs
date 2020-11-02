using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddDbContext();
            services.AddRepositories();
            services.AddUseCases();
        }
    }
}
