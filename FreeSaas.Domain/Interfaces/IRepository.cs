using System.Linq.Expressions;

namespace FreeSaas.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
                
        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);

        void RemoveRange(IEnumerable<TEntity> items);

        void Modify(TEntity item);

        void TrackItem(TEntity item);

        void Merge(TEntity persisted, TEntity current);

        void Merge(object persisted, object current);

        void Commit();

        void Rollback();

        TEntity Get(Int32 id);

        TEntity Get(string id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Where<TOrderBy>(Expression<Func<TEntity, bool>> where,
                                            Expression<Func<TEntity, TOrderBy>> orderBy, 
                                            bool ascending = true);

        IQueryable<TEntity> Where<TOrderBy>(Expression<Func<TEntity, bool>> where,
                                            int skip,
                                            int take,
                                            Expression<Func<TEntity, TOrderBy>> orderBy,
                                            bool ascending = true);

        IQueryable<TEntity> OrderBy<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy,
                                              bool ascending = true);
        
        IEnumerable<TEntity> AllMatching<KProperty>(Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);

        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        long Count();
    }
}
