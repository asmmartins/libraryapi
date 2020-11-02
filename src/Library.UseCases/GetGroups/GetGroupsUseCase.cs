using AutoMapper;
using Library.Application.UseCases.GetGroups;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Groups;
using Library.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.GetGroups
{
    public class GetGroupsUseCase : IGetGroupsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Group> _groupRepository;

        public GetGroupsUseCase(
            IMapper mapper,
            IRepository<Group> GroupRepository)
        {
            _mapper = mapper;
            _groupRepository = GroupRepository;
        }

        public async Task<IEnumerable<GroupDto>> Execute(string inep)
        {
            var groups = await GetGroupByInep(inep);
            return _mapper.Map<IEnumerable<GroupDto>>(groups);
        }

        private async Task<IEnumerable<Group>> GetGroupByInep(string inep)
        {
            var groups = await _groupRepository.GetAll();
            return groups?.Where(ps => ps.PublicSchool.Inep == inep?.Trim());
        }
    }
}
