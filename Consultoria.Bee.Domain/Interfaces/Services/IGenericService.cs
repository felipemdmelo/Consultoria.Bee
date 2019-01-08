using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Bee.Domain.Interfaces.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(long? id);
        Task<List<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task DisableAsync(TEntity obj);
        void Dispose();
    }
}
