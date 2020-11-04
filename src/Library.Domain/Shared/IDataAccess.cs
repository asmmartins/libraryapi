using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Shared
{
    public interface IDataAccess
    {        
        Task<IEnumerable<T>> GetAll<T>(string collectionName);        
    }
}
