using Microsoft.Extensions.DependencyInjection;
using Library.Application.UseCases.CreateGroup;
using Library.Application.UseCases.CreatePublicSchool;
using Library.Application.UseCases.GetGroup;
using Library.Application.UseCases.GetGroups;
using Library.Application.UseCases.GetPublicSchool;
using Library.Application.UseCases.GetPublicSchools;
using Library.UseCases.CreateGroup;
using Library.UseCases.CreatePublicSchool;
using Library.UseCases.GetGroup;
using Library.UseCases.GetGroups;
using Library.UseCases.GetPublicSchool;
using Library.UseCases.GetPublicSchools;

namespace Library.Infra.Ioc
{
    internal static class UseCasesDependecyInjection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreatePublicSchoolUseCase, CreatePublicSchoolUseCase>();
            services.AddTransient<ICreateGroupUseCase, CreateGroupUseCase>();
            services.AddTransient<IGetPublicSchoolUseCase, GetPublicSchoolUseCase>();
            services.AddTransient<IGetGroupsUseCase, GetGroupsUseCase>();
            services.AddTransient<IGetGroupUseCase, GetGroupUseCase>();
            services.AddTransient<IGetPublicSchoolsUseCase, GetPublicSchoolsUseCase>();
        }
    }
}
