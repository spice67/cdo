using INT002.Entities.Common;
using ME.Core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Data
{
    public interface ICustomerRepository : IDataRepository<CustomerInfo>
    {

    }
    public class CustomerRepository : DataRepositoryBase<CustomerInfo, CustomerCtx>, ICustomerRepository
    {
        public CustomerRepository(CustomerCtx ctx) : base(ctx)
        {
        }

        protected override async Task<bool> AddEntity(CustomerCtx entityContext, CustomerInfo entity)
        {
            entityContext.Add(entity);

            return await entityContext.SaveChangesAsync() > 0;
        }

        protected override Task<IEnumerable<CustomerInfo>> GetEntities(CustomerCtx entityContext)
        {
            throw new NotImplementedException();
        }

        protected override CustomerInfo GetEntity(CustomerCtx entityContext, string id)
        {
            throw new NotImplementedException();
        }

        protected override async Task<CustomerInfo> GetEntity(CustomerCtx entityContext, string id, string pk)
        {
            CustomerInfo? r = await entityContext.FindAsync<CustomerInfo>(id, pk);

            return r;
  
        }

        protected override Task<bool> Remove(CustomerCtx entityContext, CustomerInfo entity)
        {
            throw new NotImplementedException();
        }

        protected override string Remove(CustomerCtx entityContext, string id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> UpdateEntity(CustomerCtx entityContext, CustomerInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
