using System.Threading.Tasks;

namespace Library.Application.UseCases.RemoveSubject
{
    public interface IRemoveSubjectUseCase
    {
        Task Execute(RemoveSubjectRequest RemoveSubjectRequest);
    }
}