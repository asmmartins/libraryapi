using AutoMapper;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Subjects;
using Library.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UseCases.GetSubject
{
    public class GetSubjectUseCase : IGetSubjectUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Subject> _subjectRepository;

        public GetSubjectUseCase(
            IMapper mapper,
            IRepository<Subject> subjectRepository)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectDto> Execute(Guid id)
        {
            var Subject = await GetSubjectById(id);
            return _mapper.Map<SubjectDto>(Subject);
        }

        private async Task<Subject> GetSubjectById(Guid id)
        {
            var subjects = await _subjectRepository.GetAll();
            return subjects?.FirstOrDefault(ps => ps.Id == id);
        }
    }
}
