using AutoMapper;
using Library.Application.UseCases.GetPublicSchool;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Authors;
using Library.Domain.Groups;
using Library.Domain.PublicSchools;
using Library.Domain.Shared.ValueObjects.Addresses;

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
    }
}
