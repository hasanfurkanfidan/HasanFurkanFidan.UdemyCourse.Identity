using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Spesification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.DataAccess
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            using var context = new TContext();
            await context.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new TContext();
            if (expression!=null)
            {
                return await context.Set<TEntity>().Where(expression).ToListAsync();

            }
            return await context.Set<TEntity>().ToListAsync();

        }

        public async Task<List<TEntity>> GetListWithSpecQuery(ISpesification<TEntity> spesification)
        {
            var query = ApplySpesification(spesification);
            return await query.ToListAsync();
        }
        private IQueryable<TEntity> ApplySpesification(ISpesification<TEntity> spesification)
        {
            var context = new TContext();

            return SpesificationEvaulator<TEntity>.GetQuery(context.Set<TEntity>().AsQueryable(), spesification);
        }
        public async Task<TEntity> GetWithSpecQuery(ISpesification<TEntity> spesification)
        {
            var query = ApplySpesification(spesification);
            return await query.FirstOrDefaultAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().FindAsync(id);
        }
    }
}
