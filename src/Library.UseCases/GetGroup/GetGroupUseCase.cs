using AutoMapper;
using Library.Application.UseCases.GetGroup;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Groups;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.GetGroup
{
    public class GetGroupUseCase : IGetGroupUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Group> _groupRepository;

        public GetGroupUseCase(
            IMapper mapper,
            IRepository<Group> GroupRepository)
        {
            _mapper = mapper;
            _groupRepository = GroupRepository;
        }

        public async Task<GroupDto> Execute(Guid id)
        {
            var group = await GetGroupById(id);
            return _mapper.Map<GroupDto>(group);
        }

        private async Task<Group> GetGroupById(Guid id)
        {
            var groups = await _groupRepository.GetAll();
            return groups?.FirstOrDefault(ps => ps.Id == id);
        }
    }
}
