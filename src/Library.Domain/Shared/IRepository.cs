using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Shared
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task Save(T aggregation);
        Task<IEnumerable<T>> GetAll();
        Task Remove(T aggregation);
        Task<T> GetById(Guid id);
    }
}