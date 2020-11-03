using Library.Domain.Authors;
using Library.Domain.Shared;
using Library.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository.Authors
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Author aggregation)
        {
            var existent = await GetById(aggregation.Id);

            if (existent == null)
                _context.Authors.Add(aggregation);
            else
                _context.Authors.Update(aggregation);

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task Remove(Author aggregation)
        {
            _context.Authors.Remove(aggregation);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}