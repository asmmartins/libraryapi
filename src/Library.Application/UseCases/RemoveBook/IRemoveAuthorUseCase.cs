using System.Threading.Tasks;

namespace Library.Application.UseCases.RemoveBook
{
    public interface IRemoveBookUseCase
    {
        Task Execute(RemoveBookRequest RemoveBookRequest);
    }
}