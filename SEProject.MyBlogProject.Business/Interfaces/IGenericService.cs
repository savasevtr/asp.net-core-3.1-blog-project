using SEProject.MyBlogProject.Entities.Interfaces;
//using System;
using System.Collections.Generic;
//using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        //Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        //Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        //Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        //Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}