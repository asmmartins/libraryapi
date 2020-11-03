using System;

namespace Library.Application.UseCases.Shared.Dtos
{
    public class PublicSchoolDto
    {
        public Guid Id { get; set; }
        public string Inep { get; set; }
        public string Name { get; set; }
    }
}