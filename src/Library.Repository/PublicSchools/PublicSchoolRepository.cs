﻿using Library.Domain.PublicSchools;
using Library.Domain.Shared;
using Library.Repository.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository.PublicSchools
{
    public class PublicSchoolRepository : IRepository<PublicSchool>
    {
        private readonly PublicSchoolDbContext _context;

        public PublicSchoolRepository(PublicSchoolDbContext context)
        {
            _context = context;
        }

        public async Task Save(PublicSchool aggregation)
        {
            _context.Save(aggregation);
        }


        public async Task<IEnumerable<PublicSchool>> GetAll()
        {
            return _context.GetAll();
        }

        public async Task Remove(PublicSchool aggregation)
        {
            _context.Remove(aggregation);
        }
    }
}