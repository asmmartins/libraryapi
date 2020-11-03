using AutoMapper;
using Library.Application.UseCases.GetSubjects;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UseCases.GetSubjects
{
    public class GetSubjectsUseCase : IGetSubjectsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Subject> _subjectRepository;

        public GetSubjectsUseCase(
            IMapper mapper,
            IRepository<Subject> subjectRepository)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<SubjectDto>> Execute()
        {
            var subjects = await _subjectRepository.GetAll();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
    }
}
