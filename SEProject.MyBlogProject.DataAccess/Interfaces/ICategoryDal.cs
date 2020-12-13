using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}