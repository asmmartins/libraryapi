using Library.Domain.Groups;
using Library.Domain.Shared;
using Library.Repository.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository.Groups
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly GroupDbContext _context;

        public GroupRepository(GroupDbContext context)
        {
            _context = context;
        }

        public async Task Save(Group aggregation)
        {
            _context.Save(aggregation);
        }


        public async Task<IEnumerable<Group>> GetAll()
        {
            return _context.GetAll();
        }

        public async Task Remove(Group aggregation)
        {
            _context.Remove(aggregation);
        }
    }
}