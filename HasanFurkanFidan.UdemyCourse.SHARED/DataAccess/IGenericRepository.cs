using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Spesification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetListWithSpecQuery(ISpesification<TEntity> spesification);

        Task<TEntity> GetWithSpecQuery(ISpesification<TEntity> spesification);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
