using Library.Domain.Shared.ValueObjects.Addresses;

namespace Library.Application.UseCases.Shared.Dtos
{
    public class AddressDto
    {
        public string ZipCode { get; set; }
        public string BaseAddress { get; set; }
        public string ComplementAddress { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public State State { get; set; }
    }
}
