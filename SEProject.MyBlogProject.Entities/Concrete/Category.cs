using SEProject.MyBlogProject.Entities.Interfaces;
using System.Collections.Generic;

namespace SEProject.MyBlogProject.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}