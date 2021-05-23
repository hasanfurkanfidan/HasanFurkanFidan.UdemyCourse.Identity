using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.BusinessServices
{
    public class GenericService<TEntity> : IGenericService<TEntity>
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity>genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _genericRepository.DeleteAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetListAsync(null);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }
    }
}
