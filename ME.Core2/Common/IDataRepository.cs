using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INT002.Entities.Common
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, new()
    {
        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

       Task<bool>  Remove(T entity);

        string Remove(string id);

        Task<IEnumerable<T>> Get();

        T Get(string id);

        /// <summary>
        /// id = primary key, pk = partitionkey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        Task<T> Get(string id, string pk);
    }
}
