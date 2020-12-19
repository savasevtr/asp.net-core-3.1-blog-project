using Microsoft.EntityFrameworkCore;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            using var context = new BlogContext();

            var blogs = await context.Blogs
                 .Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, categoryBlog) => new
                 {
                     blog = blog,
                     categoryBlog = categoryBlog,
                 })
                 .Where(I => I.categoryBlog.CategoryId == categoryId)
                 .Select(I => new Blog
                 {
                     Id = I.blog.Id,
                     Title = I.blog.Title,
                     ShortDescription = I.blog.ShortDescription,
                     Description = I.blog.Description,
                     ImagePath = I.blog.ImagePath,
                     PostedTime = I.blog.PostedTime,
                     AppUser = I.blog.AppUser,
                     AppUserId = I.blog.AppUserId,
                     CategoryBlogs = I.blog.CategoryBlogs,
                     Comments = I.blog.Comments
                 }).ToListAsync();

            return blogs;
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            var context = new BlogContext();

            return await context.Categories.Join(context.CategoryBlogs, c => c.Id, cb => cb.CategoryId, (category, categoryBlog) => new
            {
                category = category,
                categoryBlog = categoryBlog
            }).Where(I => I.categoryBlog.BlogId == blogId).Select(I => new Category
            {
                Id = I.category.Id,
                Name = I.category.Name
            }).ToListAsync();
        }

        public async Task<List<Blog>> GetLastFiveAsync()
        {
            using var context = new BlogContext();

            return await context.Blogs.OrderByDescending(I => I.PostedTime).Take(5).ToListAsync();
        }
    }
}