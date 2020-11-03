using Library.Domain.Groups;
using System.Collections.Generic;

namespace Library.Repository.Shared
{
    public class GroupDbContext
    {
        private readonly IList<Group> groups;

        public GroupDbContext()
        {
            groups = new List<Group>();
        }

        public void Save(Group Group)
        {
            groups.Remove(Group);
            groups.Add(Group);
        }

        public IEnumerable<Group> GetAll() => groups;

        public void Remove(Group Group)
        {
            groups.Remove(Group);
        }
    }
}