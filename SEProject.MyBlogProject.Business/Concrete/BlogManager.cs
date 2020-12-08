using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}