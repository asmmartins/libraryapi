using System.Threading.Tasks;

namespace Library.Application.UseCases.CreateBook
{
    public interface ICreateBookUseCase
    {
        Task Execute(CreateBookRequest CreateBookRequest);
    }
}