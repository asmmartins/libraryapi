using System;
using System.Collections.Generic;

namespace Library.Application.UseCases.Shared.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public int Edition { get; set; }
        public string PublicationYear { get; set; }
        public decimal Price { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}
