using System.Threading.Tasks;

namespace Library.Application.UseCases.CreateGroup
{
    public interface ICreateGroupUseCase
    {
        Task Execute(CreateGroupRequest CreateGroupRequest);
    }
}