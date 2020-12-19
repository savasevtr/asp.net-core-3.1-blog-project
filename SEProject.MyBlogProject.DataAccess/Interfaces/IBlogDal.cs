using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Interfaces
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetLastFiveAsync();
    }
}