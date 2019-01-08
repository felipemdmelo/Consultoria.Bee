using Consultoria.Bee.Domain.Entities.Base;
using Consultoria.Bee.Domain.Interfaces.Repositories;
using Consultoria.Bee.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consultoria.Bee.Domain.Services
{
    public class GenericService<TEntity> : IDisposable, IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        
        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }

        public async Task DisableAsync(TEntity obj)
        {
            (obj as AbstractEntity).Inativar();
            await _repository.UpdateAsync(obj);
        }
    }
}
