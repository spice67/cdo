using INT002.Entities.Common;
using ME.Core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Data
{
    public interface ITransactionRepository : IDataRepository<Transaction>
    {
        public Task<IEnumerable<Transaction>> GetTransactions(int span, string accountNo);
    }

    public class TransactionRepository : DataRepositoryBase<Transaction, TransactionCtx>, ITransactionRepository
    {
        public TransactionRepository(TransactionCtx ctx) : base(ctx)
        {
        }

        public Task<IEnumerable<Transaction>> GetTransactions(int span, string accountNo)
        {
            var _trans = ((TransactionCtx)_dbContext).Transactions.Where(d=>d.accountNo.Equals(accountNo)).AsQueryable();

            var transactions = _trans.Take(span);
            return (Task<IEnumerable<Transaction>>)transactions;
        }

        protected override Task<bool> AddEntity(TransactionCtx entityContext, Transaction entity)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Transaction>> GetEntities(TransactionCtx entityContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Be aware that the id here pertains to the accountNo not the transId itself
        /// </summary>
        /// <param name="entityContext"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override Transaction GetEntity(TransactionCtx entityContext, string id)
        {
            var _trans = entityContext.Transactions.Select(s=>(Transaction)s).Where(d=>d.transId.Equals(id));

            return _trans.FirstOrDefault();
        }

        protected override Task<Transaction> GetEntity(TransactionCtx entityContext, string id, string pk)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> Remove(TransactionCtx entityContext, Transaction entity)
        {
            throw new NotImplementedException();
        }

        protected override string Remove(TransactionCtx entityContext, string id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> UpdateEntity(TransactionCtx entityContext, Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
