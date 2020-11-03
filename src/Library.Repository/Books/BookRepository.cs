using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository.Books
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Book aggregation)
        {
            var existent = await GetById(aggregation.Id);

            if (existent == null)
                _context.Books.Add(aggregation);
            else
                _context.Books.Update(aggregation);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Include(x => x.BookAuthors).Include(x => x.BookSubjects).ToListAsync();
        }

        public async Task Remove(Book aggregation)
        {
            _context.Books.Remove(aggregation);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.Include(x => x.BookAuthors).Include(x => x.BookSubjects).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}