using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Interfaces;
//using System;
using System.Collections.Generic;
//using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _genericDal.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        //public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        //{
        //    return await _genericDal.GetAllAsync(filter);
        //}

        //public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        //{
        //    return await _genericDal.GetAllAsync(filter, keySelector);
        //}

        //public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        //{
        //    return await _genericDal.GetAllAsync(keySelector);
        //}

        //public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        //{
        //    return await _genericDal.GetAsync(filter);
        //}

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}