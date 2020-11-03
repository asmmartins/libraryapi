using AutoMapper;
using Library.Application.UseCases.GetPublicSchool;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.Groups;
using Library.Domain.PublicSchools;
using Library.Domain.Shared.ValueObjects.Addresses;
using Library.Domain.Subjects;

namespace Library.Infra.Ioc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreatePublicSchoolMap();
            CreateAddressMap();
            CreateGroupMap();
            CreateAuthorMap();
            CreateSubjectMap();
        }

        private void CreateAddressMap()
        {
            CreateMap<Address, AddressDto>();
        }

        private void CreatePublicSchoolMap()
        {
            CreateMap<PublicSchool, GetPublicSchoolResponse>();

            CreateMap<PublicSchool, PublicSchoolDto>();                
        }

        private void CreateGroupMap()
        {
            CreateMap<Group, GroupDto>();
        }

        private void CreateAuthorMap()
        {
            CreateMap<Author, AuthorDto>();
        }

        private void CreateSubjectMap()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}
