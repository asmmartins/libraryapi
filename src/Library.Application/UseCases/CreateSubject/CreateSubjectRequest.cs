using System;

namespace Library.Application.UseCases.CreateSubject
{
    public class CreateSubjectRequest
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
    }
}