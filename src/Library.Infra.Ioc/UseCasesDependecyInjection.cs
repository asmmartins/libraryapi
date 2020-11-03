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
using Library.Application.UseCases.CreateAuthor;
using Library.UseCases.CreateAuthor;
using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.GetAuthors;
using Library.UseCases.GetAuthor;
using Library.UseCases.GetAuthors;
using Library.Application.UseCases.GetSubjects;
using Library.UseCases.GetSubjects;
using Library.UseCases.GetSubject;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.CreateSubject;
using Library.UseCases.CreateSubject;
using Library.UseCases.RemoveAuthor;
using Library.Application.UseCases.RemoveAuthor;
using Library.UseCases.RemoveSubject;
using Library.Application.UseCases.RemoveSubject;

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

            services.AddTransient<ICreateAuthorUseCase, CreateAuthorUseCase>();
            services.AddTransient<IGetAuthorUseCase, GetAuthorUseCase>();
            services.AddTransient<IGetAuthorsUseCase, GetAuthorsUseCase>();
            services.AddTransient<IRemoveAuthorUseCase, RemoveAuthorUseCase>();

            services.AddTransient<ICreateSubjectUseCase, CreateSubjectUseCase>();
            services.AddTransient<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddTransient<IGetSubjectsUseCase, GetSubjectsUseCase>();
            services.AddTransient<IRemoveSubjectUseCase, RemoveSubjectUseCase>();
        }
    }
}
