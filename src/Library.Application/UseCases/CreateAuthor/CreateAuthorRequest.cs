using System;

namespace Library.Application.UseCases.CreateAuthor
{
    public class CreateAuthorRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}