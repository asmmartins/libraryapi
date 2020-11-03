using System.Threading.Tasks;

namespace Library.Application.UseCases.RemoveAuthor
{
    public interface IRemoveAuthorUseCase
    {
        Task Execute(RemoveAuthorRequest RemoveAuthorRequest);
    }
}