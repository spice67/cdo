using ME.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Data
{
    public class CustomerAccntCtx : DbContext
    {
        public CustomerAccntCtx(DbContextOptions<CustomerAccntCtx> options) : base(options)
        { }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("CustomerAccounts");
            #endregion

            #region Container
            modelBuilder.Entity<CustomerAccount>();
            #endregion

            #region PartitionKey
            modelBuilder.Entity<CustomerAccount>().HasPartitionKey("customerId");
            modelBuilder.Entity<CustomerAccount>().HasKey("customerId");
            #endregion

            #region Discriminators
            modelBuilder.Entity<CustomerAccount>().HasNoDiscriminator();
            #endregion
        }
    }
}
