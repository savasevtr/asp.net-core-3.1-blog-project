using Microsoft.EntityFrameworkCore;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using var context = new BlogContext();

            return await context.Categories.OrderByDescending(I => I.Id).Include(I => I.CategoryBlogs).ToListAsync();
        }
    }
}