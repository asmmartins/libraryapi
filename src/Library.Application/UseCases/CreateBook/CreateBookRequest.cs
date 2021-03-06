﻿using System;
using System.Collections.Generic;

namespace Library.Application.UseCases.CreateBook
{
    public class CreateBookRequest
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public int Edition { get; set; }
        public string PublicationYear { get; set; }
        public decimal Price { get; set; }
        public List<Guid> Authors { get; set; }
        public List<Guid> Subjects { get; set; }
    }
}