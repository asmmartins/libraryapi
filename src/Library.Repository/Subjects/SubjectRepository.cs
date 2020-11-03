using Library.Domain.Subjects;
using Library.Domain.Shared;
using Library.Repository.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Subjects
{
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly LibraryDbContext _context;

        public SubjectRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Subject aggregation)
        {
            var existent = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == aggregation.Id);

            if (existent == null)                            
                _context.Subjects.Add(aggregation);            
            else
                _context.Subjects.Update(aggregation);
            
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task Remove(Subject aggregation)
        {
            _context.Subjects.Remove(aggregation);
            await _context.SaveChangesAsync();
        }
    }
}