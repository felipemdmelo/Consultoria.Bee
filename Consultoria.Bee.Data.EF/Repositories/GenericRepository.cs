using Consultoria.Bee.Data.EF.Context;
using Consultoria.Bee.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Bee.Data.EF.Repositories
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected BeeContext _db;
        
        public GenericRepository(BeeContext db)
        {
            _db = db;
        }
        
        public async Task AddAsync(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            await _db.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _db.Dispose();
        }
        
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
        
        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }
        
        public async Task UpdateAsync(TEntity obj)
        {
            _db.Set<TEntity>().Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
