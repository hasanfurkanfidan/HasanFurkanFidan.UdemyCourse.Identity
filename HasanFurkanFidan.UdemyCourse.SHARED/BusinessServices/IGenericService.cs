using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.BusinessServices
{
    public interface IGenericService<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
