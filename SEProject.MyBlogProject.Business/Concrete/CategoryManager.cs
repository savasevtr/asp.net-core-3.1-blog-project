using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;

        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}