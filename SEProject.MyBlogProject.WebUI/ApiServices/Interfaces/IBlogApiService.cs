using SEProject.MyBlogProject.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.ApiServices.Interfaces
{
    public interface IBlogApiService
    {
        Task<List<BlogListModel>> GetAllAsync();
        Task<BlogListModel> GetByIdAsync(int id);
        Task<List<BlogListModel>> GetAllByCategoryId(int id);
        Task AddAsync(BlogAddModel model);
        Task UpdateAsync(BlogUpdateModel model);
        Task DeleteAsync(int id);
    }
}