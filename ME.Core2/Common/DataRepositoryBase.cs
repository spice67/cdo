using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace INT002.Entities.Common
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, new()
        where U : DbContext
    {

        protected readonly DbContext _dbContext;

        public DataRepositoryBase(U ctx)
        {
            _dbContext = ctx;
        }

        protected abstract Task<bool> AddEntity(U entityContext, T entity);

        protected abstract Task<bool> UpdateEntity(U entityContext, T entity);

        protected abstract Task<IEnumerable<T>> GetEntities(U entityContext);

        protected abstract T GetEntity(U entityContext, string id);

        protected abstract Task<bool> Remove(U entityContext, T entity);

        protected abstract string Remove(U entityContext, string id);

        protected abstract Task<T> GetEntity(U entityContext, string id, string pk);

        public Task<bool> Remove(T entity)
        {
            return Remove((U)_dbContext, entity);
        }

        public string Remove(string id)
        {
            return Remove((U)_dbContext, id);
        }

        public Task<IEnumerable<T>> Get()
        {
            return GetEntities((U)_dbContext);
        }

        public T Get(string id)
        {
            return GetEntity((U)_dbContext, id);
        }

        public Task<bool> Add(T entity)
        {
            return AddEntity((U)_dbContext, entity);
        }

        public Task<bool> Update(T entity)
        {
            return UpdateEntity((U)_dbContext, entity);
        }

        public async Task<T> Get(string id, string pk)
        {
            return await GetEntity((U)_dbContext, id, pk);
        }
    }
}
