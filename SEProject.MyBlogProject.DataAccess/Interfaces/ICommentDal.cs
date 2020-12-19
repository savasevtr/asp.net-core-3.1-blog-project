using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.DataAccess.Interfaces
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId);
    }
}