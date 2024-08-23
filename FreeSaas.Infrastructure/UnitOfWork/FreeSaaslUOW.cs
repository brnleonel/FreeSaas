using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FreeSaas.Infrastructure.UnitOfWork
{
    public class FreeSaasUOW : DbContext, IQueryableUnitOfWork
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private IDbContextTransaction _transaction = null;

        #region DbSet
        public DbSet<Banco> Banco { get; set; }

        public DbSet<Cbo> Cbo { get; set; }

        public DbSet<Cep> Cep { get; set; }

        public DbSet<Cest> Cest { get; set; }

        public DbSet<Cfop> Cfop { get; set; }

        public DbSet<Cnae> Cnae { get; set; }

        public DbSet<Ibge> Ibge { get; set; }

        public DbSet<Ncm> Ncm { get; set; }
        #endregion

        public FreeSaasUOW(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString,
                optBuilder =>
                {
                    optBuilder.MigrationsAssembly(typeof(FreeSaasUOW).GetTypeInfo().Assembly.GetName().Name);
                }
            );
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TEntity> CreateSet<TEntity>()
        where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Modified;
        }

        public void DeleteObject<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Deleted;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public virtual void BeginTransaction()
        {
            _transaction?.Dispose();
            _transaction = base.Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public virtual void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public void ChangeDatabase(string database)
        {
            _connectionString = database;
            Database.GetDbConnection().ConnectionString = database;
        }

        public string GetDatabase()
        {
            return Database.GetDbConnection().Database;
        }

        public string GetConnectionString()
        {
            return Database.GetDbConnection().ConnectionString;
        }

        public void EnableChangeTracking(bool enable = true)
        {
            ChangeTracker.AutoDetectChangesEnabled = enable;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new BancoEC());
            modelBuilder.AddConfiguration(new CboEC());
            modelBuilder.AddConfiguration(new CepEC());
            modelBuilder.AddConfiguration(new CestEC());
            modelBuilder.AddConfiguration(new CfopEC());
            modelBuilder.AddConfiguration(new CnaeEC());
            modelBuilder.AddConfiguration(new IbgeEC());
            modelBuilder.AddConfiguration(new NcmEC());
        }
    }
}
