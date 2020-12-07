using Microsoft.EntityFrameworkCore;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new BlogContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new BlogContext();

            return await context.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
