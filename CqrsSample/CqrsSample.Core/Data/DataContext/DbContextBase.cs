using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Transactions;
using Autofac;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.Data.DataContext
{
    public abstract class DbContextBase:DbContext
    {
        internal IComponentContext IComponentContext;

        public DbContextBase()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public long UserOfDbContextId { get; set; }

        public override int SaveChanges()
        {
            var changesCount = 0;

            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                FillAuditables();

                RaiseBeforeCrudEvents();

                changesCount = base.SaveChanges();

                RaiseAfterCrudEvents();

                RaiseTransactionalEvents(new ReadOnlyDataContext(this), scope);

                scope.Complete();
            }

            RaiseNonTransactionalEvents();

            return changesCount;
        }

        private void RaiseAfterCrudEvents()
        {
            foreach (var changeSet in ChangeTracker.Entries())
            {
                var type = changeSet.Entity.GetType();

                if (changeSet.State == EntityState.Modified)
                {
                    //ResolveUpdateEventHandlers
                }
                else if (changeSet.State == EntityState.Added)
                {

                }
                else if (changeSet.State == EntityState.Deleted)
                {

                }
            }
        }

        private void RaiseBeforeCrudEvents()
        {
            foreach (var changeSet in ChangeTracker.Entries())
            {
                var type = changeSet.Entity.GetType();

                if (changeSet.State == EntityState.Modified)
                {

                }
                else if (changeSet.State == EntityState.Added)
                {

                }
                else if (changeSet.State == EntityState.Deleted)
                {

                }
            }
        }

        private void RaiseTransactionalEvents(IReadOnlyDataContext readOnlyDbContext, TransactionScope scope)
        {
            
        }

        private void FillAuditables()
        {
            foreach (var changeSet in ChangeTracker.Entries<AuditableEntity>())
            {
                var auditableEntity = changeSet.Entity as AuditableEntity;

                if (changeSet.Property(p => p.CreateDateTime).IsModified || changeSet.Property(p => p.LastModifiedDateTime).IsModified)
                {
                    throw new DbEntityValidationException("Access Violated");
                }

                if (changeSet.State == EntityState.Modified)
                {
                    auditableEntity.LastModifierId = UserOfDbContextId;
                }
                else if (changeSet.State == EntityState.Added)
                {
                    auditableEntity.CreateDateTime = DateTime.Now;
                }
            }
        }

        private void RaiseNonTransactionalEvents()
        {
           
        }

        private void RaiseTransactionalEvents()
        {
            
        }

        private void RaiseEvents()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapEntitiesToTables(modelBuilder);
        }

        private void MapEntitiesToTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Fine");

            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            var dbContextAssembly = Assembly.GetAssembly(this.GetType());

            var entityTypes =
             dbContextAssembly
            .GetTypes().Where(t => t.IsSubclassOf(typeof(Entity)));

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type)
                      .Invoke(modelBuilder, new object[] { });
            }

            modelBuilder.Types()
                .Configure(c => c.ToTable(c.ClrType.Name));

        }
    }
}