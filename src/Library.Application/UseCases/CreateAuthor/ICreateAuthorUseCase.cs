using System.Threading.Tasks;

namespace Library.Application.UseCases.CreateAuthor
{
    public interface ICreateAuthorUseCase
    {
        Task Execute(CreateAuthorRequest CreateAuthorRequest);
    }
}