using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static void AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguration(configuration);
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddUseCases();
        }
    }
}
