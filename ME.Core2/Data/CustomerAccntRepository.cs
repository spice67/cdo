using INT002.Entities.Common;
using ME.Core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ME.Core2.Entities.CustomerAccount;

namespace ME.Core2.Data
{
    public interface ICustomerAccntRepository : IDataRepository<CustomerAccountInfo>
    {

    }
    public class CustomerAccntRepository : DataRepositoryBase<CustomerAccountInfo, CustomerAccntCtx>, ICustomerAccntRepository
    {
        public CustomerAccntRepository(CustomerAccntCtx ctx) : base(ctx)
        {
        }

        protected override async Task<bool> AddEntity(CustomerAccntCtx entityContext, CustomerAccountInfo entity)
        {
            entityContext.Add(entity);

            return await entityContext.SaveChangesAsync() > 0;
        }

        protected override Task<IEnumerable<CustomerAccountInfo>> GetEntities(CustomerAccntCtx entityContext)
        {
            throw new NotImplementedException();
        }

        protected override CustomerAccountInfo GetEntity(CustomerAccntCtx entityContext, string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Take note that the id can represent anyting from sn id, personnumber id, eu id, etc.
        /// The primary key (pk) represents the collection entity such as the account no.
        /// </summary>
        /// <param name="entityContext"></param>
        /// <param name="id"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        protected override async Task<CustomerAccountInfo> GetEntity(CustomerAccntCtx entityContext, string id, string pk)
        {
            CustomerAccountInfo? ca = await entityContext.FindAsync<CustomerAccountInfo>(id, pk);

            return ca;
        }

        protected override Task<bool> Remove(CustomerAccntCtx entityContext, CustomerAccountInfo entity)
        {
            throw new NotImplementedException();
        }

        protected override string Remove(CustomerAccntCtx entityContext, string id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> UpdateEntity(CustomerAccntCtx entityContext, CustomerAccountInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
