using System.Threading.Tasks;

namespace Library.Application.UseCases.CreatePublicSchool
{
    public interface ICreatePublicSchoolUseCase
    {
        Task Execute(CreatePublicSchoolRequest CreatePublicSchoolRequest);
    }
}