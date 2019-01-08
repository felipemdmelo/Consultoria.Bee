using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consultoria.Bee.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(long? id);
        Task<List<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        void Dispose();
    }
}
