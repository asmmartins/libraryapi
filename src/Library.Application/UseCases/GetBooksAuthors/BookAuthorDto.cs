using System;

namespace Library.Application.UseCases.GetBooksAuthors
{
    public class BookAuthorDto
    {
        public Guid authorId { get; set; }
        public string authorName { get; set; }
        public int books { get; set; }
    }
}
