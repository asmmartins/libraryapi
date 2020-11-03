using System.Threading.Tasks;

namespace Library.Application.UseCases.CreateSubject
{
    public interface ICreateSubjectUseCase
    {
        Task Execute(CreateSubjectRequest CreateSubjectRequest);
    }
}