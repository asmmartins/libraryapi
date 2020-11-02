using Library.Application.UseCases.Shared.Dtos;

namespace Library.Application.UseCases.CreatePublicSchool
{
    public class CreatePublicSchoolRequest
    {

        public string Inep { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}