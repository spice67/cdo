using ME.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Data
{
    public class CustomerCtx : DbContext
    {
        public CustomerCtx(DbContextOptions<CustomerCtx> options) : base(options)
        { }

        public DbSet<CustomerInfo> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("Customers");
            #endregion

            #region Container
            modelBuilder.Entity<CustomerInfo>();
            #endregion

            #region PartitionKey
            modelBuilder.Entity<CustomerInfo>().HasPartitionKey("id");
            modelBuilder.Entity<CustomerInfo>().HasKey("id");
            #endregion

            #region Discriminators
            modelBuilder.Entity<CustomerInfo>().HasNoDiscriminator();
            #endregion
        }
    }
}
