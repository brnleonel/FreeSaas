using FreeSaas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FreeSaas.Infrastructure.Interfaces
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        IQueryableUnitOfWork _UnitOfWork;

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            if (item != null)
            {
                GetSet().Add(item);
            }
        }

        public virtual void AddRange(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                var newSet = _UnitOfWork.CreateSet<TEntity>();
                newSet.AddRange(items);
            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.Attach(item);
                GetSet().Remove(item);
            }
        }

        public virtual void RemoveRange(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                GetSet().RemoveRange(items);
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.Attach<TEntity>(item);
            }
        }

        public virtual void Modify(TEntity item)
        {
            if (item != null)
            {
                _UnitOfWork.SetModified(item);
            }
        }

        public virtual TEntity Get(int id)
        {
            return GetSet().Find(id);
        }

        public virtual TEntity Get(string id)
        {
            return GetSet().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsNoTracking().AsEnumerable();
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return GetSet().Where(predicate);
        }

        public virtual IQueryable<TEntity> Where<TOrderBy>(Expression<Func<TEntity, bool>> where,
                                                           Expression<Func<TEntity, TOrderBy>> orderBy,
                                                           bool ascending = true)
        {
            if (ascending)
                return GetSet().Where(where).OrderBy(orderBy);
            else
                return GetSet().Where(where).OrderByDescending(orderBy);
        }

        public virtual IQueryable<TEntity> Where<TOrderBy>(Expression<Func<TEntity, bool>> where,
                                                           int skip,
                                                           int take,
                                                           Expression<Func<TEntity, TOrderBy>> orderBy,
                                                           bool ascending = true)
        {
            if (ascending)
                return GetSet().Where(where).Skip(skip).Take(take).OrderBy(orderBy);
            else
                return GetSet().Where(where).Skip(skip).Take(take).OrderByDescending(orderBy);
        }

        public virtual IQueryable<TEntity> OrderBy<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, bool ascending = true)
        {
            if (ascending)
                return GetSet().OrderBy(orderBy);
            else
                return GetSet().OrderByDescending(orderBy);
        }

        public virtual IEnumerable<TEntity> AllMatching<KProperty>(Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            if (ascending)
            {
                return GetSet().OrderBy(orderByExpression)
                           .AsEnumerable();
            }
            else
            {
                return GetSet().OrderByDescending(orderByExpression)
                           .AsEnumerable();
            }
        }

        public virtual IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter)
                       .AsQueryable();
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual void Merge(object persisted, object current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual void Commit()
        {
            _UnitOfWork.Commit();
        }

        public virtual void Rollback()
        {
            _UnitOfWork.RollbackChanges();
        }

        public virtual long Count()
        {
            return GetSet().Count();
        }

        public void Dispose()
        {
            if (_UnitOfWork != null)
            {
                _UnitOfWork.Dispose();
            }
        }

        private DbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
    }
}
