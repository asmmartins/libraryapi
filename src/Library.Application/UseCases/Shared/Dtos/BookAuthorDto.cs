using System;

namespace Library.Application.UseCases.Shared.Dtos
{
    public class BookAuthorDto
    {        
        public Guid AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
