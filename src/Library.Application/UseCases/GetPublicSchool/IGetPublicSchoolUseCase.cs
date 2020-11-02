using System.Threading.Tasks;

namespace Library.Application.UseCases.GetPublicSchool
{
    public interface IGetPublicSchoolUseCase
    {
        Task<GetPublicSchoolResponse> Execute(string inep);
    }
}