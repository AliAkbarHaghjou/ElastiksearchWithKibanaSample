using System.Linq.Expressions;

namespace ElastikSearchWithKibanaSample.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
         Task Add(TEntity entity);
         Task Update(TEntity entity);

         Task Remove(TEntity entity);

         IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

         Task<IEnumerable<TEntity>> GetAllAsync();

         ValueTask<TEntity> GetByIdAsync(int id);
}
}
