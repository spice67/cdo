using ME.Core2.Entities;
using System;
using Microsoft.EntityFrameworkCore.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ME.Core2.Data
{
    public class TransactionCtx : DbContext
    {
        public TransactionCtx(DbContextOptions<TransactionCtx> options): base(options)
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("Transactions");
            #endregion

            #region Container
            modelBuilder.Entity<Transaction>();
            #endregion

            #region PartitionKey
            modelBuilder.Entity<Transaction>().HasPartitionKey("accountNo");
            modelBuilder.Entity<Transaction>().HasKey("accountNo");
            #endregion

            #region Discriminators
            modelBuilder.Entity<Transaction>().HasNoDiscriminator();
            #endregion
        }
    }
}
