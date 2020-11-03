using AutoMapper;
using Library.Application.UseCases.GetSubject;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System;
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
            var Subject = await _subjectRepository.GetById(id);
            return _mapper.Map<SubjectDto>(Subject);
        }
    }
}
